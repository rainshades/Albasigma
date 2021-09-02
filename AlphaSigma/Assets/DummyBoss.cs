using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

namespace Albasigma.ARPG
{
    public class DummyBoss : MonoBehaviour, ICombatEntity
    {
        [SerializeField]
        GameObject RangedAttackPoint;
        [SerializeField]
        GameObject RangedAttackPrefab;

        [SerializeField]
        float currenthealth, health, phase_1_damage, phase_2_damage, attack_cooldown;

        [SerializeField]
        GameObject Phase2_Timeline, Death_Timeline; 

        bool phase_1, phase_2, attacking;

        public bool FightStarted; 

        int RangedAttackCount;

        NavMeshAgent agent;

        [SerializeField]
        Transform ChargeHitbox;

        [SerializeField]
        Vector3 chargehitrange;

        bool charging;

        [SerializeField]
        LayerMask hitmask, IgnoreLayer;

        BossAnimatorMethods ani;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            ani = GetComponentInChildren<BossAnimatorMethods>(); 
        }

        public void Attack(float damage, GameObject entity)
        {
            if (phase_1)
            {
                if(RangedAttackCount <= 5 && !attacking)
                {
                    StartCoroutine(RangedAttack(attack_cooldown));
                }
                else if(!attacking)
                {
                    StartCoroutine(ChargeAttack(attack_cooldown));
                }
            }
            else if (phase_2)
            {

            }
        }

        IEnumerator RangedAttack(float timer)
        {
            ani.PlayRanged(); 
            RangedAttackCount++;
            attacking = true;

            LaunchProjectile(RangedAttackPrefab, FindObjectOfType<PlayerCombat>().gameObject.transform.position, phase_1_damage);

            yield return new WaitForSecondsRealtime(timer);

            attacking = false; 
        }

        public void LaunchProjectile(GameObject entity, Vector3 target, float damage)
        {
            GameObject go = Instantiate(entity, RangedAttackPoint.transform.position + Vector3.forward, Quaternion.identity);

            go.GetComponent<Projectile>().SetProjectile(target, 2.5f, 0.5f, damage, hitmask);
            go.GetComponent<Projectile>().IgnoreLayer = IgnoreLayer;
        }//Instantiates a projectile 

        IEnumerator ChargeAttack(float timer)
        {
            attacking = true;
            charging = true; 

            Vector3 target = FindObjectOfType<PlayerCombat>().transform.position;
            agent.SetDestination(target);
            agent.speed = 8;            

            yield return new WaitForSecondsRealtime(timer);
            if (transform.position == agent.destination)
            {
                attacking = false;
                charging = false; 
            }
            RangedAttackCount = 0; 
        }

        public void OnDeath()
        {
            ani.PlayDie(); 
        }

        public void Death()
        {
            Death_Timeline.gameObject.SetActive(true); 
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


        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(ChargeHitbox.position, chargehitrange);
        }


        // Update is called once per frame
        void Update()
        {
            if (!attacking)
            {
                transform.LookAt(FindObjectOfType<PlayerCombat>().gameObject.transform);
              //  RangedAttackPoint.transform.position = FindObjectOfType<PlayerCombat>().transform.position; 
            }

            ChargeHitbox.gameObject.SetActive(charging);
            ani.PlayMoving(charging);

            if (charging && Physics.CheckBox(ChargeHitbox.position, chargehitrange / 2, Quaternion.identity, hitmask))
            {
                Collider[] col = Physics.OverlapBox(ChargeHitbox.position, chargehitrange, Quaternion.identity, hitmask);
                foreach(Collider collider in col)
                {
                    collider.GetComponentInParent<PlayerCombat>().TakeDamage(phase_1_damage);
                    Vector3 KnockbackDirection = (transform.position - collider.transform.position) * - 1;
                    collider.GetComponent<EntityMovement>().KnockbackCalc(collider.GetComponent<EntityMovement>(),
                        KnockbackDirection);
                }
            }

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