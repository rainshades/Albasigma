using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Albasigma.ARPG
{
    public class BattleSpace : MonoBehaviour
    {
        [SerializeField]
        List<GameObject> Enemies = new List<GameObject>();

        ArenaManager manager;

        [SerializeField]
        BattleSpace NextInBattlechain;

        [SerializeField]
        GameObject[] Walls;

        PlayableDirector EndOfBattleScene; 

        public bool AllEnemiesDefeated { get => Enemies.Count == 0; }

        private void Awake()
        {
            manager = GetComponentInParent<ArenaManager>();
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).tag == "Enemy")
                {
                    Enemies.Add(transform.GetChild(i).gameObject);
                }
            }
        }

        private void Update()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i] == null)
                {
                    Enemies.RemoveAt(i);
                }
            }
            if(Enemies.Count == 0)
            {
                OnDisable(); 
            }
        }

        private void OnEnable()
        {
            manager.CurrentBattle = this; 
        }

        private void OnDisable()
        {
            if (NextInBattlechain != null)
            {
                NextInBattlechain.gameObject.SetActive(true); 
            }
            else
            {
                manager.CurrentBattle = null;
            }

            if (Walls.Length > 0)
            {
                foreach (GameObject go in Walls)
                {
                    go.SetActive(false);
                }
            }

            if(EndOfBattleScene != null)
            {
                EndOfBattleScene.gameObject.SetActive(true); 
            }
        }

    }
}