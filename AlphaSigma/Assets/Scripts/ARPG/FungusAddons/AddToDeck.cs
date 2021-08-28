using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Albasigma.Cards;
using Albasigma.ARPG;
using Albasigma.UI;

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
                }
                else
                {
                    Bag.CardsInBag.Add(spellCard); 
                }
            }

            if(Deck.spellsInHand.Count == 1)
            {
                Deck.RefreshHand();
                FindObjectOfType<HandUI>().Reset();

            }

            Continue(); 
        }
    }
}