using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.Cards;

namespace Albasigma.ARPG
{
    /// <summary>
    /// Accessor for the current Deck's SO
    /// </summary>
    public class DeckOfCards : MonoBehaviour
    {
        public Deck DeckSO;

        public void Awake()
        {
            if(DeckSO.spellsInHand.Count == 0)
                DeckSO.DrawHand(); 
            //Fills the hand which is empty on awake
        }       
    }
}