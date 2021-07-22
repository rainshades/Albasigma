using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Albasigma.ARPG;

namespace Albasigma.ARPG
{
    [CreateAssetMenu(fileName ="New Player Decision Tracker",menuName = "Player Decision Tracker")]
    public class DecisionTracker : ScriptableObject
    {
        public List<bool> Decisions = new List<bool>();         
    }
}

namespace Albasigma.FungusAddon
{
}