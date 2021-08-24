using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Albasigma.ARPG; 

namespace Albasigma.FungusAddon
{
    [CommandInfo("Friendly", "Stat Growth Decision", "Making the one time choice of making a stat growth choice")]
    public class StatGrowthChoice : Command
    {
        public PlayerStats PlayersStats;
        public GrowthType GrowthType; 
        
        public override void Execute()
        {
            base.Execute();
            PlayersStats.PlayerLevel.GrowthType = GrowthType;
            Continue(); 
        }
    }
}