using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albasigma.ARPG
{
    /// <summary>
    /// Used to create Animation Events for the player animations 
    /// </summary>
    public class PlayerAnimatorActionAddon : MonoBehaviour
    {
        PlayerCombat PC;
        PlayerMovement PM; 

        private void Awake()
        {
            PC = GetComponentInParent<PlayerCombat>();
            PM = GetComponentInParent<PlayerMovement>(); 
        }

        public void OnAttackCollision()
        {
            PC.AttackCollision(); 
        }//Player hits on this frame

        public void AttackFinished()
        {
            PC.Attacking = false; 
        }//Player is done attacking

        public void AttackBegin()
        {
           PC.Attacking = true;
        }//Player began attacking

        public void LungePlayerForward()
        {
            PM.Lunge(); 
        }

        public void ControlsOff()
        {
            PM.Disable(); 
        }

        public void ControlsOn()
        {
            PM.Enable(); 
        }

        public void ClimpUp()
        {
            PM.ClimbUpFromLedge(); 
        }
    }
}