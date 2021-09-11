using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Albasigma.ARPG;
using Cinemachine;
using UnityEngine.InputSystem;

namespace Albasigma.FungusAddon
{
    [CommandInfo("Friendly", "Stop the Player", "Disables the controls")]
    public class PausePlayer : Command
    {
        bool UsingKeypad
        {
            get
            {
                var gamepad = Gamepad.current;
                return gamepad == null;
            }
        }

        public override void Execute()
        {
            base.Execute();
            FindObjectOfType<PlayerMovement>().Disable();
            Continue(); 
        }
    }
}