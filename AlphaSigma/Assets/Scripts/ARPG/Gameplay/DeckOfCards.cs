using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.Cards;

namespace Albasigma.ARPG
{
    public class DeckOfCards : MonoBehaviour
    {
        public AllyCard Ally_1;
        public AllyCard Ally_2;

        public List<SpellCard> spellsInHand;
        public List<SpellCard> PlayerDeck;
        public List<SpellCard> Deck; 

        public void Awake()
        {
            Deck.AddRange(PlayerDeck);

            if(Ally_1 != null)
            {
                Deck.AddRange(Ally_1.AllyDeck);
            }
            if (Ally_2 != null)
            {
                Deck.AddRange(Ally_2.AllyDeck);
            }
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