using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.Cards
{
    /// <summary>
    /// These are the Ally's you pick up along the story who all have their own special cards
    /// </summary>
    [CreateAssetMenu(fileName ="New Ally", menuName ="Ally")]
    public class AllyCard : ScriptableObject
    {
        public List<SpellCard> AllyDeck = new List<SpellCard>();
        public Sprite AllyImage; 
    } //Allies add specific spells into your play deck 
}