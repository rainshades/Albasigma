using Fungus;
using Albasigma.ARPG;
using Cinemachine;
using UnityEngine.InputSystem;

namespace Albasigma.FungusAddon
{
    [CommandInfo("Friendly", "Continue Player", "Enables player controls")]
    public class ContinuePlayer : Command
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
            FindObjectOfType<PlayerMovement>().Enable();
            Continue(); 
        }
    }
}