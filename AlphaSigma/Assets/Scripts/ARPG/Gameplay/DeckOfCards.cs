using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.Cards;

namespace Albasigma.ARPG
{
    public class DeckOfCards : MonoBehaviour
    {
        public Deck DeckSO;

        public void Awake()
        {
            if(DeckSO.spellsInHand.Count == 0)
                DeckSO.DrawHand(); 
        }       
    }
}