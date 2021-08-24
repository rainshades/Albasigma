using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    public interface IThreshHold
    {
        public void ActivateThreshhold();
    }

    public class ThreshHold : MonoBehaviour, IThreshHold
    {
        [SerializeField]
        GameObject TimeLineObject;

        public void ActivateThreshhold()
        {
            TimeLineObject.SetActive(true); 
        }
    }
}