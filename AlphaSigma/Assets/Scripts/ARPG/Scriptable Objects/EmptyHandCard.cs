using UnityEngine;
using Albasigma.ARPG;

namespace Albasigma.Cards
{
    public class EmptyHandCard : MonoBehaviour, ISelfEffect
    {        
        public void OnSelfActivation()
        {
            FindObjectOfType<DeckOfCards>().DeckSO.RefreshHand(); 
        }//Refrehses the current hand
    }
}
