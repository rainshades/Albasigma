using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    public class DummyCombat : MonoBehaviour, ICombatEntity
    {
        public float Currenthealth, MaxHealth;
        public int expPrize, drivePrize, moneyPrize; 

        public void OnDeath()
        {
            PlayerCombat.Instance.GainExp(expPrize);
            PlayerCombat.Instance.CurrentDrive += drivePrize;
            PlayerCombat.Instance.gameObject.GetComponent<Bag>().currency += moneyPrize; 

            Destroy(gameObject);
        }

        public void Attack(float damage, GameObject entity)
        {

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