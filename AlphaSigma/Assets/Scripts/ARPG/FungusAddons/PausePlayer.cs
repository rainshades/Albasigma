using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Albasigma.ARPG;

namespace Albasigma.FungusAddon
{
    [CommandInfo("Friendly", "Stop the Player", "Disables the controls")]
    public class PausePlayer : Command
    {
        public override void Execute()
        {
            base.Execute();
            FindObjectOfType<PlayerMovement>().Disable();
            Continue(); 
        }
    }

    [CommandInfo("Friendly", "Start the Player", "Disables the controls")]
    public class ContinuePlayer : Command
    {
        public override void Execute()
        {
            base.Execute();
            FindObjectOfType<PlayerMovement>().Enable();
            Continue(); 
        }
    }
}