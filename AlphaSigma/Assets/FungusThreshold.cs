using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; 

namespace Albasigma.ARPG
{
    public class FungusThreshold : MonoBehaviour, IThreshHold
    {
        [SerializeField]
        string FungusText; 
        public void ActivateThreshhold()
        {
            FindObjectOfType<Flowchart>().ExecuteBlock(FungusText); 
        }
    }
}