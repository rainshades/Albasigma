using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    public class BossAnimatorMethods : MonoBehaviour
    {
        Animator ani;
        DummyBoss Dummy;
        private void Awake()
        {
            ani = GetComponent<Animator>();
            Dummy = GetComponentInParent<DummyBoss>();
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
            ani.SetBool("Walk Forward", moving);
        }

        public void PlayRanged()
        {
            ani.SetTrigger("Ranged");
        }

        public void PlayAttackAni_1()
        {
            ani.SetTrigger("Attack 1");
        }

        public void PlayAttackAni_2()
        {
            ani.SetTrigger("Attack 2");
        }
    }
}