using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables; 

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
        List<GameObject> BattleSpace = new List<GameObject>();

        public bool AllEnemiesDefeated { get => CurrentBattle == null;  }

        PlayableDirector transitionCanvas;

        public BattleSpace CurrentBattle; 

        private void Start()
        {
            MusicHandler.ArenaManager = this; 
            GameManager.Instance.CurrentArena = this;
            for(int i = 0; i < transform.childCount; i++)
            {
                if(transform.GetChild(i).tag == "Battle")
                {
                    BattleSpace.Add(transform.GetChild(i).gameObject);
                }
            }
        }

        private void Update()
        {
            for(int i = 0; i < BattleSpace.Count; i++)
            {
                if(BattleSpace[i] == null)
                {
                    BattleSpace.RemoveAt(i); 
                }
            }
        }
    }
}