using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.Cards;

namespace Albasigma.ARPG
{
    public interface IInteractable
    {
        public void Interact();
    } 

    public class ShopMono : MonoBehaviour, IInteractable
    {
        public ShopSO Shop;
        public ShopItem CurrentShopItem; 

        public void Interact()
        {
            OpenStore(); 
        }

        private void OpenStore()
        {
            Debug.Log("Open Shop");
        }
    }
}