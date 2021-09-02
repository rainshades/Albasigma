using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    public class AnimatorMethods : MonoBehaviour
    {
        public DummyCombat Dummy;
        Animator ani;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            Dummy = GetComponentInParent<DummyCombat>(); 
        }

        public void OnAttackCollision()
        {
            Dummy.AttackCollision();
        }

        public void OnDeath()
        {
            Dummy.Death(); 
        }

        public void PlayDie()
        {
            ani.SetTrigger("Die");
        }

        public void PlayHit()
        {
            ani.SetTrigger("Hit");
        }

        public void PlayMoving(bool moving)
        {
            ani.SetBool("Moving", moving);
        }

        public void PlayAttackAni()
        {
            ani.SetTrigger("Attack");
        }
    }
}
