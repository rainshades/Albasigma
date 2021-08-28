using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    public class DummyBoss : MonoBehaviour, ICombatEntity
    {
        [SerializeField]
        GameObject RangedAttackPoint;

        [SerializeField]
        int AttackRange;

        [SerializeField]
        float currenthealth, health, phase_1_damage, phase_2_damage, attack_cooldown, attack_cooldown_timer;

        [SerializeField]
        string attack_1, attack_2;

        [SerializeField]
        GameObject Timeline_1, Timeline_2; 

        bool phase_1, phase_2, attacking;

        public bool FightStarted; 

        int RangedAttackCount; 

        public void Attack(float damage, GameObject entity)
        {
            if (phase_1)
            {
                if(RangedAttackCount <= 5 && !attacking)
                {
                    StartCoroutine(RangedAttack(2.5f));
                }
                else if(!attacking)
                {
                    StartCoroutine(ChargeAttack(2.5f));
                }
            }
            else if (phase_2)
            {

            }
        }

        IEnumerator RangedAttack(float timer)
        {
            GetComponentInChildren<Animator>().SetTrigger("Cast Spell");
            RangedAttackCount++;
            attacking = true; 
            yield return new WaitForSecondsRealtime(timer);

            attacking = false; 
        }

        IEnumerator ChargeAttack(float timer)
        {
            transform.LookAt(FindObjectOfType<PlayerCombat>().gameObject.transform);
            transform.Translate(Vector3.forward);
            yield return new WaitForSecondsRealtime(timer);
            RangedAttackCount = 0; 

        }


        public void OnDeath()
        {
            GetComponentInChildren<Animator>().SetTrigger("Die");
        }

        public void TakeDamage(float damage)
        {
            if(currenthealth == 0)
            {
                OnDeath(); 
            }
            else
            {
                currenthealth -= damage; 
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }



        // Update is called once per frame
        void Update()
        {
            if (FightStarted)
            {
                Attack(0, null); 
            }

            if(currenthealth > health / 2)
            {
                phase_1 = true;
                phase_2 = false;
            }
            else
            {
                phase_2 = true;
                phase_1 = false; 
            }

        }
    }
}