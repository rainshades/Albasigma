using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albasigma.ARPG
{
    [RequireComponent(typeof(Conversation))]
    public class FriendlyNPC : MonoBehaviour, IInteractable
    {
        [SerializeField]
        string ConversationBlockName;

        public void Interact()
        {
            GetComponent<Conversation>().PlayConversation(ConversationBlockName);
        }
    }
}