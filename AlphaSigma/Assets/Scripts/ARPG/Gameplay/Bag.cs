using System.Collections.Generic;
using UnityEngine;
using Albasigma.Cards;

namespace Albasigma.ARPG
{
    [CreateAssetMenu(fileName = "Bag", menuName = "Player Bag")]
    public class Bag : ScriptableObject
    {
        public int currency;
        public List<SpellCard> CardsInBag = new List<SpellCard>();
        //The bag only contains currency and the deck
        //Things like potions will be handled as spells
        //"key items" and other items that are not usable in transactions will be stored elseware
        //IF they are implemented
    }
}