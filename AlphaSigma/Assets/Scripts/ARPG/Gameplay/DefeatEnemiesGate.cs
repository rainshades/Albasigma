using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    public class DefeatEnemiesGate : MonoBehaviour, IGate
    { 

        [SerializeField]
        List<GameObject> Enemies;

        [SerializeField]
        protected bool TurnOn; 

        void CrossOffList()
        {
            for(int i = 0; i < Enemies.Count; i++)
            {
                if(Enemies[i] == null)
                {
                    Enemies.RemoveAt(i); 
                }
            }
        }

        private void Update()
        {
            OpenGate(); 
        }

        public bool CanOpen()
        {
            CrossOffList(); 
            return Enemies.Count <= 0; 
        }

        public void OpenGate()
        {
            if (CanOpen())
            {
                gameObject.SetActive(TurnOn); 
            }
        }
    }
}