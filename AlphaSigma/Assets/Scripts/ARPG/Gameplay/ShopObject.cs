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

    public class ShopObject : MonoBehaviour, IInteractable
    {
        public ShopSO Shop;
        public ShopItem CurrentShopItem;

        [SerializeField]
        string ConversationBlockName; 

        public void Interact()
        {
            OpenStore(); 
        }

        private void OpenStore()
        {
            GetComponent<Conversation>().PlayConversation(ConversationBlockName);

            Debug.Log("Open Shop");
        }
    }
}