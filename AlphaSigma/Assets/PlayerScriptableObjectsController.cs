using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.ARPG;
using Albasigma.Cards;

namespace Albasigma
{
    [RequireComponent(typeof(GameManager))]
    public class PlayerScriptableObjectsController : MonoBehaviour
    {
        [SerializeField]
        GameObject PlayerSet; //The object that holds the player's components

        public SkillList SkillSO;
        public DecisionTracker Tracker;
        public Bag Bag;
        public Deck DeckSO;
        public PlayerStats StatsSO;

        public void ResetPlayerComponents()
        {
            Bag.Reset(); 
            DeckSO.Reset();
            SkillSO.Reset();
            Tracker.Reset();
            StatsSO.Reset(); 
        }
    }
}