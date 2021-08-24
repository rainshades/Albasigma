using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.UI; 

namespace Albasigma.Cards
{
    /// <summary>
    /// Contains the All related cards for the deck
    /// </summary>
    [CreateAssetMenu(fileName = "New Deck", menuName = "Deck")]
    public class Deck : ScriptableObject
    {
        public AllyCard Ally_1;
        public AllyCard Ally_2;

        public SpellCard DrawNewCards; 

        public List<SpellCard> spellsInHand;
        public List<SpellCard> PlayerDeck;
        public List<SpellCard> CompleteDeck;

        public void DrawHand()
        {
            if(CompleteDeck.Count == 0)
            {
                CompleteDeck.AddRange(PlayerDeck);

                if (Ally_1 != null)
                {
                    CompleteDeck.AddRange(Ally_1.AllyDeck);
                }
                if (Ally_2 != null)
                {
                    CompleteDeck.AddRange(Ally_2.AllyDeck);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    spellsInHand.Add(CompleteDeck[0]);
                    CompleteDeck.RemoveAt(0);
                }
                catch
                {
                    Debug.Log("Deck running empty");
                }
            }
            spellsInHand.Add(DrawNewCards); 
        }//Draw a hand of 5 cards

        public void RefreshHand()
        {
            spellsInHand.Clear();
            DrawHand();
            FindObjectOfType<HandUI>().Reset(); 
        }//Dump cards and draw a hand of 5



    }
}