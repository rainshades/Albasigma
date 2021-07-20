using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Albasigma.ARPG
{
    public class DummyCombat : MonoBehaviour, ICombatEntity
    {
        public float Currenthealth, MaxHealth, AttackRange, baseAttackCooldown;
        protected float currentAttackCooldown = 0; 
        public int expPrize, drivePrize, moneyPrize;
        
        public Transform AttackPoint;
        [SerializeField]
        protected LayerMask PlayerLayer;

        public SpriteRenderer HealthBar; 

        private void Awake()
        {
            if(TryGetComponent(out DummyMovement dummy))
               PlayerLayer = dummy.PlayerLayer;
        }

        public void OnDeath()
        {
            PlayerCombat.Instance.GainExp(expPrize);
            PlayerCombat.Instance.CurrentDrive += drivePrize;
            PlayerCombat.Instance.gameObject.GetComponent<BagObject>().bag.currency += moneyPrize; 

            Destroy(gameObject);
        }

        private void Update()
        {
            Collider[] col = Physics.OverlapSphere(AttackPoint.position, AttackRange, PlayerLayer);
            try
            {
                if(currentAttackCooldown <= 0)
                    Attack(2, col[0].gameObject);
            }
            catch
            {
                //nothing to attack
            }

            if(currentAttackCooldown > 0)
            {
                GetComponent<DummyMovement>().agent.isStopped = true;
                currentAttackCooldown -= Time.deltaTime; 
            }
            else
            {
                GetComponent<DummyMovement>().agent.isStopped = false;
            }

            HealthBar.transform.localScale = new Vector3(Currenthealth / MaxHealth, 1, 1); 
        }

        public void Attack(float damage, GameObject entity)
        {
            entity.GetComponent<ICombatEntity>().TakeDamage(damage);
            currentAttackCooldown = baseAttackCooldown;
            Vector3 KnockbackDirection = (AttackPoint.position - entity.transform.position) * -1; 
            GetComponent<EntityMovement>().KnockbackCalc(entity.GetComponent<EntityMovement>(), 
                KnockbackDirection); 

        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(AttackPoint.position, AttackRange); 
        }

        public void TakeDamage(float damage)
        {
            Currenthealth -= damage;

            if(Currenthealth <= 0)
            {
                OnDeath(); 
            }
        }
    }
}