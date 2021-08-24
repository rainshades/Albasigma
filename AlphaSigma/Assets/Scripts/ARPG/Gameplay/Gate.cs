using System.Collections;
using UnityEngine;

namespace Albasigma.ARPG
{
    public interface IGate
    {
        bool CanOpen();
        void  OpenGate();
    }


    public class ObjectInInventoryGate : MonoBehaviour, IGate
    {
        private void Update()
        {
            OpenGate(); 
        }

        public bool CanOpen()
        {
            return false; 
        }

        public void OpenGate()
        {
            if (CanOpen())
            {
                gameObject.SetActive(false); 
            }
        }
    }
}