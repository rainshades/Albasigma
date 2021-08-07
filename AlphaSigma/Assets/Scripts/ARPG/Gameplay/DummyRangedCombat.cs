using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    /// <summary>
    /// Ranged Combat for the dummy
    /// </summary>
    public class DummyRangedCombat : DummyCombat, ICombatEntity
    {
        public GameObject projectilePrefab;
        bool recentlyFired; //Tells movement whether or not it can run away or fire again

        public bool RecentlyFired => recentlyFired; 

        [SerializeField]
        LayerMask IgnoreLayer; //Layers for the projectile to ignore. 

        private void Update()
        {
            transform.LookAt(FindObjectOfType<PlayerCombat>().transform); 

            Collider[] col = Physics.OverlapSphere(AttackPoint.position, AttackRange, PlayerLayer);
            try
            {
                if (currentAttackCooldown <= 0)
                    Attack(2,col[0].gameObject);
            }
            catch
            {
                //nothing to attack
            }

            if(currentAttackCooldown <= baseAttackCooldown / 2)
            {
                recentlyFired = false; 
            }


            if (currentAttackCooldown > 0)
            {
                currentAttackCooldown -= Time.deltaTime;
            }
        }

        public new void Attack(float damage, GameObject entity)
        {
            LaunchProjectile(projectilePrefab, entity.transform.position, damage);
            currentAttackCooldown = baseAttackCooldown;
        }//Attacking launches a projectile 

        public void LaunchProjectile(GameObject entity, Vector3 target, float damage)
        {
            GameObject go = Instantiate(entity, AttackPoint.position + Vector3.forward, Quaternion.identity);

            go.GetComponent<Projectile>().SetProjectile(target, 0.5f, damage, PlayerLayer);
            go.GetComponent<Projectile>().IgnoreLayer = IgnoreLayer;
            recentlyFired = true; 
        }//Instantiates a projectile 
    }
}