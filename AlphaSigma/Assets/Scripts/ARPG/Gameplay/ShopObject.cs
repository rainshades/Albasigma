using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.Cards;

namespace Albasigma.ARPG
{
    /// <summary>
    /// Signifies the player can interact with the object
    /// </summary>
    public interface IInteractable
    {
        public void Interact();//When the player interacts with this object
    } 

    /// <summary>
    /// Contains the individual shop
    /// </summary>
    public class ShopObject : MonoBehaviour, IInteractable
    {
        public ShopSO Shop;
        public ShopItem CurrentShopItem;

        [SerializeField]
        string ConversationBlockName; 

        public void Interact()
        {
            OpenStore(); 
        }// opens shop when player interacts

        private void OpenStore()
        {
            GetComponent<Conversation>().PlayConversation(ConversationBlockName);

            Debug.Log("Open Shop");
        }
    }
}