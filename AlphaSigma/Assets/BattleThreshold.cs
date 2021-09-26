using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    public class BattleThreshold : MonoBehaviour, IThreshHold
    {
        [SerializeField]
        BattleSpace BattleSpace;

        [SerializeField]
        GameObject[] Wall; 

        public void ActivateThreshhold()
        {
            BattleSpace.gameObject.SetActive(true); 
            foreach(GameObject go in Wall)
            {
                go.SetActive(true); 
            }
        }
    }
}