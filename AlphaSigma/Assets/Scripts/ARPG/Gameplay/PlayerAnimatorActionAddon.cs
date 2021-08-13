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

        private void Awake()
        {
            PC = GetComponentInParent<PlayerCombat>(); 
        }

        public void OnAttackCollision()
        {
            PC.AttackCollision(); 
        }//Player hits on this frame

        public void AttackFinished()
        {
            GetComponentInParent<PlayerCombat>().Attacking = false; 
        }//Player is done attacking

        public void AttackBegin()
        {
            GetComponentInParent<PlayerCombat>().Attacking = true;
        }//Player began attacking

        public void LungePlayerForward()
        {
            GetComponentInParent<PlayerMovement>().Lunge(); 
        }
    }
}