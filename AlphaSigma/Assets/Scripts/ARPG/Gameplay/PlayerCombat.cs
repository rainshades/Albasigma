using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albasigma.ARPG
{
    public class PlayerCombat : MonoBehaviour, CombatEntity
    {
        public Transform CardLockOn;
        public float LockOnRange;
        public LayerMask EnemyLayer; 

        public float Currenthealth, MaxHealth;
        public float CurrentDrive, MaxDrive;
             
        Collider[] EnemiesInRange;

        Vector3 ReturnPostion;

        PlayerControls Controls;

        public bool Blocking;

        public float AttackRange;
        public Transform AttackPoint; 

        private void Awake()
        {
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
                Attack(5, col.gameObject); 
            }

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


        public void Attack(int damage, GameObject entity)
        {
            Debug.Log("Does " + damage + " to " + entity.name); 
        }

        public void TakeDamage(int damage)
        {
            Debug.Log("Took " + damage); 
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