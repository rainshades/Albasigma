using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    public class InterestingObject : MonoBehaviour, IInteractable
    {
        [SerializeField]
        string ConversationBlockName;
        private void Awake()
        {
            if (!GetComponent<Conversation>())
            {
                gameObject.AddComponent<Conversation>();
            }
        }

        public void Interact()
        {
            OpenConversation();
        }// opens the item description when player interacts


        private void OpenConversation()
        {
            GetComponent<Conversation>().PlayConversation(ConversationBlockName);
        }
    }
}