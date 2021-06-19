using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albasigma.Cards
{
    [CreateAssetMenu(fileName = "New Spell", menuName = "Spell Card")]
    public class SpellCard : ScriptableObject
    {
        //Desc, Sprite, damage/effects
        public Sprite Image;
        public int cost;
    }
}