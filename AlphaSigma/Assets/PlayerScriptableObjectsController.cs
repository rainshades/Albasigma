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

        public Deck DeckSO;
        public SkillList SkillSo;
        public DecisionTracker DecisionTrackerSo;
        public PlayerStats StatsSO; 

        public void ResetPlayerComponents()
        {
            DeckSO.Reset();
            SkillSo.Reset();
            DecisionTrackerSo.Reset();
            StatsSO.Reset(); 
        }
    }
}