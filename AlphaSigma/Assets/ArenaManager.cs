using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    public class ArenaManager : MonoBehaviour
    {
        [SerializeField]
        List<GameObject> Enemies = new List<GameObject>();

        public bool AllEnemiesDefeated { get => Enemies.Count == 0;  }

        private void Start()
        {
            GameManager.Instance.CurrentArena = this; 
            for(int i = 0; i < transform.childCount; i++)
            {
                if(transform.GetChild(i).tag == "Enemy")
                {
                    Enemies.Add(transform.GetChild(i).gameObject);
                }
            }
        }
        private void OnEnable()
        {
            
        }
    }
}