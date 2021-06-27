using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albasigma.ARPG
{
    public class PlayerCombat : MonoBehaviour, ICombatEntity
    {
        PlayerLevelSystem PlayerLevel = new PlayerLevelSystem(); 

        public Transform CardLockOn;
        public float LockOnRange;
        public LayerMask EnemyLayer; 

        public float Currenthealth, MaxHealth;
        public float CurrentDrive, MaxDrive;

        public float AttackDamage; 

        Collider[] EnemiesInRange;

        Vector3 ReturnPostion;

        PlayerControls Controls;

        public bool Blocking;

        public float AttackRange;
        public Transform AttackPoint;
        
        public static PlayerCombat Instance { get; set; }

        public void GainExp(int EXP)
        {
            PlayerLevel.Experience += EXP; 
        }


        private void Awake()
        {
            Instance = this; 

            ReturnPostion = CardLockOn.localPosition;
            Controls = new PlayerControls();

            Controls.Player.AttackInteract.performed += AttackInteract_performed;
            Controls.Player.Block.performed += Block_performed;
            Controls.Player.Block.canceled += ctx => Blocking = false; 
        }

        private void Block_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Block(); 
        }

        private void AttackInteract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Collider[] colliders = Physics.OverlapSphere(AttackPoint.position, AttackRange, EnemyLayer);

            foreach(Collider col in colliders)
            {
                Attack(AttackDamage, col.gameObject); 
            }

        }

        public void OnDeath()
        {
            //GameOver
        }


        private void Update()
        {
            EnemiesInRange = Physics.OverlapSphere(transform.position, LockOnRange, EnemyLayer);
            if(EnemiesInRange.Length > 0)
            {
                CardLockOn.position = EnemiesInRange[0].transform.position;
            }
            else
            {
                CardLockOn.localPosition = ReturnPostion; 
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, LockOnRange);

            Gizmos.DrawWireSphere(CardLockOn.position, 0.5f);

            Gizmos.DrawWireSphere(AttackPoint.position, AttackRange); 
        }


        public void Attack(float damage, GameObject entity)
        {
            entity.GetComponentInParent<ICombatEntity>().TakeDamage(damage); 
            Debug.Log("Does " + damage + " to " + entity.name); 
        }

        public void TakeDamage(float damage)
        {
            Currenthealth -= damage;

            Debug.Log("Took " + damage); 

            if(Currenthealth <= 0)
            {
                OnDeath(); 
            }
        }

        public void Block()
        {
            Blocking = true; 
            //Give bonus stats OR make direct damage immune
        }

        private void OnEnable()
        {
            Controls.Enable();
        }

        private void OnDisable()
        {
            Controls.Disable();
        }

    }
}