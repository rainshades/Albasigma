using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.Cards; 

namespace Albasigma.ARPG
{
    public class Bag : MonoBehaviour
    {
        public int currency;
        public List<SpellCard> CardsInBag = new List<SpellCard>(); 
    }
}