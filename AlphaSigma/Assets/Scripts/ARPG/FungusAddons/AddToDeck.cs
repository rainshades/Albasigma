using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Albasigma.Cards;
using Albasigma.ARPG;

namespace Albasigma.FungusAddon
{
    [CommandInfo("Friendly", "Give Player Cards", "")]
    public class AddToDeck : Command
    {
        [SerializeField]
        SpellCard[] CardsToAdd;

        [SerializeField]
        Deck Deck;
        [SerializeField]
        Bag Bag; 

        public override void Execute()
        {
            base.Execute();

            foreach (SpellCard spellCard in CardsToAdd)
            {
                //We'll determine max cards in a deck later
                //For now MaxCardCount is 10
                if (Deck.PlayerDeck.Count < 10)
                {
                    Deck.PlayerDeck.Add(spellCard);
                    if(Deck.spellsInHand.Count == 0)
                    {
                        Deck.RefreshHand(); 
                        //This will likely only be called at the beginning of the game
                    }
                }
                else
                {
                    Bag.CardsInBag.Add(spellCard); 
                }
            }
            Continue(); 
        }
    }
}