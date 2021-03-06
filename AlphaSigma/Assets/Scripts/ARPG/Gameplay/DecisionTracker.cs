using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Albasigma.ARPG;

namespace Albasigma.ARPG
{
    [System.Serializable]
    public class Decision 
    {
        public string name; 
        public bool Done; 
    }

    /// <summary>
    /// Tracks Specific gameplay decisions that will be tracked by either convesation with the Fungus Accessor 
    /// or by a script to be determined later
    /// </summary>
    [CreateAssetMenu(fileName ="New Player Decision Tracker",menuName = "Player Decision Tracker")]
    public class DecisionTracker : ScriptableObject, IReset
    {
        public Decision[] Decisions = new Decision[4];

        public void Reset()
        {
            foreach(Decision decision in Decisions)
            {
                decision.Done = false; 
            }
        }
    }
}