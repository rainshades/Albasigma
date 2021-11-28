using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.UI;
using Albasigma.ARPG;
using System.Linq; 

namespace Albasigma.Cards
{
    /// <summary>
    /// Contains the All related cards for the deck
    /// </summary>
    [CreateAssetMenu(fileName = "New Deck", menuName = "Deck")]
    public class Deck : ScriptableObject, IReset
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

            Shuffle();

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
            HandUI hand = FindObjectOfType<HandUI>();
            hand.Reset();
            hand.CardSpaceCheck(); 

        }//Dump cards and draw a hand of 5

        public void Shuffle()
        {
            List<SpellCard> TempDeck = CompleteDeck;
            List<SpellCard> Bucket = new List<SpellCard>();
            List<int>indexBucket = new List<int>();
            
            for(int i = 0; i < TempDeck.Count; i++)
            {
                int index = GetShuffleIndex(indexBucket, 0, TempDeck.Count); 
                Bucket.Add(TempDeck[index]); 
            }

            CompleteDeck = Bucket; 
            
        }

        int GetShuffleIndex(List<int> index, int min, int max)
        {
            int random = Random.Range(min, max);
            if (index.Contains(random))
            {
                GetShuffleIndex(index, min, max);
            }
            else
            {
                index.Add(random);
            }
            return random;

        }


        public void Reset()
        {
            Ally_1 = null; Ally_2 = null;
            spellsInHand.Clear();
            PlayerDeck.Clear();
            CompleteDeck.Clear(); 
        }
    }
}