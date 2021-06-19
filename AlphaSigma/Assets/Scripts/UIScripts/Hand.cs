using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.Cards; 

namespace Albasigma.UI
{
    public class Hand : MonoBehaviour
    {
        public List<SpellCard> Spells;
        public UICardObject Left, Right, Center;

        DeckOfCards Deck;

        private void Awake()
        {
            Deck = FindObjectOfType<DeckOfCards>();
            //Temporary Repalce with more perminent deck structure

            //We assume deck must be over 3 (we'll assume it is for now but this is not safe code)
            Left.SetCard(Deck.spells[0]);
            Center.SetCard(Deck.spells[1]);
            Right.SetCard(Deck.spells[2]);
        }

        public void ShiftCardLeft()
        {

        }

        public void ShiftCardRight()
        {

        }
        
    }
}