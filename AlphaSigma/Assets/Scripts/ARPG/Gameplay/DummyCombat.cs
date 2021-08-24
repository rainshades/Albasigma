using UnityEngine;
using Albasigma.UI; 
namespace Albasigma.ARPG
{
    /// <summary>
    /// Handles Combat for the melee dummy
    /// </summary>
    public class DummyCombat : MonoBehaviour, ICombatEntity
    {
        //Dummy Stats
        public float Currenthealth, MaxHealth, AttackRange, baseAttackCooldown;
        protected float currentAttackCooldown = 0; 
        public int expPrize, drivePrize, moneyPrize;
        
        public Transform AttackPoint;
        [SerializeField]
        protected LayerMask PlayerLayer;

        private void Awake()
        {
            if(TryGetComponent(out DummyMovement dummy))
               PlayerLayer = dummy.PlayerLayer;
        }

        public void OnDeath()
        {
            PlayerCombat.Instance.GainExp(expPrize);

            
            PlayerCombat.Instance.CurrentDrive += drivePrize;
            if(PlayerCombat.Instance.CurrentDrive > PlayerCombat.Instance.MaxDrive)
            {
                PlayerCombat.Instance.CurrentDrive = PlayerCombat.Instance.MaxDrive; 
            }
            PlayerCombat.Instance.gameObject.GetComponent<BagObject>().bag.currency += moneyPrize; 

            Destroy(gameObject);
        }//Grants prizes upon death 

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
            HealthBar.instance.LastHitEnemy = this; 
            if (Currenthealth <= 0)
            {
                OnDeath(); 
            }
        }
    }
}