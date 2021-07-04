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
    }
}