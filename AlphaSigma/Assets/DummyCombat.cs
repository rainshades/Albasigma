using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Albasigma.ARPG
{
    public class DummyCombat : MonoBehaviour, ICombatEntity
    {
        public float Currenthealth, MaxHealth, AttackRange;
        public int expPrize, drivePrize, moneyPrize;
        
        public Transform AttackPoint;
        LayerMask PlayerLayer;

        private void Awake()
        {
            PlayerLayer = GetComponent<DummyMovement>().PlayerLayer;
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
            if (Physics.CheckSphere(AttackPoint.position, AttackRange, PlayerLayer))
            {
                Debug.Log("Attack");  
            }
        }

        public void Attack(float damage, GameObject entity)
        {

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