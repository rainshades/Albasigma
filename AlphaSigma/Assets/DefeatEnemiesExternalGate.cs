using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    public class DefeatEnemiesExternalGate : DefeatEnemiesGate
    {
        [SerializeField]
        GameObject ExternalGate;
        
        private void Update()
        {
            OpenGate();
        }
        
        public new void OpenGate()
        {
            if (CanOpen())
            {
                ExternalGate.SetActive(TurnOn);
            }
        }
    }
}