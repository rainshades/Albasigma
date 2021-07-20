using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    public class DummyRangedCombat : DummyCombat, ICombatEntity
    {
        public GameObject projectilePrefab;

        [SerializeField]
        LayerMask IgnoreLayer;

        private void Awake()
        {
        }

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

            if (currentAttackCooldown > 0)
            {
                currentAttackCooldown -= Time.deltaTime;
            }

            HealthBar.transform.localScale = new Vector3(Currenthealth / MaxHealth, 1, 1);
        }

        public new void Attack(float damage, GameObject entity)
        {
            LaunchProjectile(projectilePrefab, entity.transform.position, damage);
            currentAttackCooldown = baseAttackCooldown;
        }

        public void LaunchProjectile(GameObject entity, Vector3 target, float damage)
        {
            GameObject go = Instantiate(entity, new Vector3(transform.position.x, 1, transform.position.z) + Vector3.forward, Quaternion.identity);


            go.GetComponent<Projectile>().SetProjectile(target, transform.localScale.z, damage, PlayerLayer);
            go.GetComponent<Projectile>().IgnoreLayer = IgnoreLayer; 
        }
    }
}