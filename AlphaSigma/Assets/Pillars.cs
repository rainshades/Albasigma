using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    public class Pillars : MonoBehaviour
    {
        public void DestoryPillars()
        {
            Debug.Log("Kill Pillars");

            for(int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

    }
}