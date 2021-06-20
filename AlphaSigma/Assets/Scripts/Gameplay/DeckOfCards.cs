using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.Cards;

namespace Albasigma
{
    public class DeckOfCards : MonoBehaviour
    {
        public List<SpellCard> spellsInHand;
        public List<SpellCard> Deck;

        public void Awake()
        {
            DrawHand(); 
        }

        public void DrawHand()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    spellsInHand.Add(Deck[i]);
                }
                catch
                {
                    Debug.Log("Deck running empty");
                }
            }
        }
    }
}