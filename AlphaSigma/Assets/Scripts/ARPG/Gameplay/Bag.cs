using System.Collections.Generic;
using UnityEngine;
using Albasigma.Cards;

namespace Albasigma.ARPG
{
    /// <summary>
    /// The bag contains currency, the deck, and key items (things that aren't tradeable)
    /// Things like potions will be handled as spells
    /// </summary>
    [CreateAssetMenu(fileName = "Bag", menuName = "Player Bag")]
    public class Bag : ScriptableObject
    {
        public int currency;
        public List<SpellCard> CardsInBag = new List<SpellCard>();        

        public List<KeyItem> Items = new List<KeyItem>(); 
    }
}