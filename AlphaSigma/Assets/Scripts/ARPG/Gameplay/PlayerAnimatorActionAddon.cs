using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albasigma.ARPG
{
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
        }

        public void AttackFinished()
        {
            GetComponentInParent<PlayerCombat>().Attacking = false; 
        }

        public void AttackBegin()
        {
            GetComponentInParent<PlayerCombat>().Attacking = true;
        }
    }
}