using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    /// <summary>
    /// Meant to hold and manage aspects for each specific Arena
    /// If all the enemies in the arena are defeated.
    /// If all the items have been recovered
    /// Will need to make children for:
    /// If this is a boss area
    /// If this is an instance
    /// </summary>
   

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