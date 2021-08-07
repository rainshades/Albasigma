using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    /// <summary>
    /// Players save at these interactable spots
    /// </summary>
    public class SavePoint : MonoBehaviour, IInteractable
    {
        public GameObject SaveText; 

        public void Interact()
        {
            Save();
        }

        public void Save()
        {
            GameManager.Instance.SaveGame();
            SaveText.GetComponent<Animator>().Play("SaveGame");
        }//Uses GameManager Save()
    }
}