using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 


namespace Albasigma.ARPG
{
    public class PlayerCombat : MonoBehaviour, ICombatEntity
    {
        [SerializeField]
        float maxComboWindowTime;
        float TimeLeftToContinueComboString = 0;

        PlayerAnimationController AC; 

        int combo; 

        PlayerLevelSystem PlayerLevel = new PlayerLevelSystem(); 

        public Transform CardLockOn;
        public float LockOnRange;
        public LayerMask EnemyLayer; 

        public float Currenthealth, MaxHealth;
        public float CurrentDrive, MaxDrive;

        public float AttackDamage; 

        Collider[] EnemiesInRange;

        Vector3 CardReturnPostion;

        public PlayerControls Controls;

        public bool Blocking, Attacking;

        public float AttackRange;
        public Transform AttackPoint;
        
        public static PlayerCombat Instance { get; set; }

        public GameObject CameraPoint; 
        bool LockedOn;
        Vector3 CameraReturnPosition;


        public void GainExp(int EXP)
        {
            PlayerLevel.Experience += EXP; 
        }

        private void Awake()
        {
            Instance = this;
            AC = GetComponent<PlayerAnimationController>(); 
            CardReturnPostion = CardLockOn.localPosition;
            Controls = new PlayerControls();

            Controls.Player.AttackInteract.performed += AttackInteract_performed;
            Controls.Player.Block.performed += Block_performed;
            Controls.Player.Block.canceled += ctx => Blocking = false;
            Controls.Player.Block.canceled += ctx => AC.StopBlock();

            Controls.Player.LockOn.performed += LockOn_performed;
        }

        private void LockOn_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            CinemachineTargetGroup Group = FindObjectOfType<CinemachineTargetGroup>();

            if (!LockedOn)
            {
                try
                {
                    CameraReturnPosition = CameraPoint.transform.position;
                    if(Group.m_Targets.Length == 1)
                    {
                        Group.AddMember(EnemiesInRange[0].transform, .5f, 0);
                    }
                    LockedOn = true;
                }
                catch
                {
                    Debug.Log("Nothing in range");
                }
            }
            else
            {
                if(Group.m_Targets.Length > 1)
                {
                    try
                    {
                        Group.RemoveMember(EnemiesInRange[0].transform);
                    }
                    catch
                    {
                        Group.RemoveMember(Group.m_Targets[1].target);
                    }
                }
                LockedOn = false; 
            }
        }

        private void Block_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Block(); 
        }

        private void AttackInteract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            AC.AttackAniTrigger();

            if (!GetComponent<PlayerMovement>().grounded)
            {
                GetComponent<PlayerMovement>().gravity *= 2.5f; 
            }


            try
            {
                GetComponent<PlayerInteractionController>().CurrentInteractable.Interact();
            }
            catch
            {
                //Nothing to interact with
            }
        }


        public void AttackCollision()
        {
            Collider[] colliders = Physics.OverlapSphere(AttackPoint.position, AttackRange, EnemyLayer);

            foreach (Collider col in colliders)
            {
                if (col.tag == "Enemy")
                    Attack(AttackDamage, col.gameObject);
                if (col.tag == "Breakable")
                    Destroy(col.gameObject); //Placeholder for the scripted destruction of said object
            }

        }

        public void OnDeath()
        {
            GameManager.Instance.GameOver(); 
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
                CardLockOn.localPosition = CardReturnPostion; 
            }
            if(TimeLeftToContinueComboString <= 0)
            {
                combo = 0;
                AC.ComboNumber(combo);
            }
            else
            {
                TimeLeftToContinueComboString -= Time.deltaTime; 
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

            if (combo <= 4)
            {
                if (TimeLeftToContinueComboString > 0)
                {
                    entity.GetComponentInParent<ICombatEntity>().TakeDamage(damage);
                    Debug.Log("Does " + damage + " to " + entity.name);
                    AC.ComboNumber(combo);
                    combo++;
                }
                //Still play animaiton for initial attack
                TimeLeftToContinueComboString = maxComboWindowTime; 
            }

        }

        public void TakeDamage(float damage)
        {
            if (!Blocking)
            {
                Currenthealth -= damage;

                Debug.Log("Took " + damage);
            }
            else
            {
                Debug.Log("Blocked");
            }

            if(Currenthealth <= 0)
            {
                OnDeath(); 
            }
        }

        public void Block()
        {
            AC.Block(); 
            Blocking = true;
            Debug.Log("Blocking");
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