using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


namespace Albasigma.ARPG
{
    /// <summary>
    /// Player combat handler
    /// References to Player Stats, Skills SO
    /// Player combat status: Attacking, blocking, taking damage, death, and locking on
    /// Combat Skills: 
    ///     Ground Pound
    ///     In Air Combo
    /// </summary>
    public class PlayerCombat : MonoBehaviour, ICombatEntity
    {
        [SerializeField]
        SkillList Skills; 

        [SerializeField]
        float maxComboWindowTime;
        float TimeLeftToContinueComboString = 0;

        PlayerAnimationController AC; 

        int combo; 

        public Transform CardLockOn;
        public float LockOnRange;
        public LayerMask EnemyLayer;

        public PlayerStats Stats;

        public PlayerLevelSystem PlayerLevel => Stats.PlayerLevel;
        public float Currenthealth { get => Stats.Currenthealth; set => Stats.Currenthealth = value; }
        public float MaxHealth => Stats.MaxHealth;
        public float CurrentDrive { get => Stats.CurrentDrive; set => Stats.CurrentDrive = value; }
        public float MaxDrive => Stats.MaxDrive;

        public float AttackDamage => Stats.Attack;

        public float AttackRange => Stats.AttackRange;

        Collider[] EnemiesInRange;

        Vector3 CardReturnPostion;

        public PlayerControls Controls;

        public bool Blocking, Attacking;

        public Transform AttackPoint;
        
        public static PlayerCombat Instance { get; set; }

        public GameObject CameraPoint; 
        bool LockedOn;
        Vector3 CameraReturnPosition;
        public bool FastFall;

        CinemachineFreeLook FreeLook; 

        public void GainExp(int EXP)
        {
            PlayerLevel.GainExperience(EXP); 
        }

        private void Awake()
        {
            Instance = this;
            AC = GetComponent<PlayerAnimationController>(); 
            CardReturnPostion = CardLockOn.localPosition;
            Controls = new PlayerControls();

            FreeLook = FindObjectOfType<CinemachineFreeLook>(); 

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
                }//Locks onto the closest enemy at the time
                //This is also the enemy that will be hit by the next spell
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
            if (!GetComponent<PlayerMovement>().grounded && Skills.Skills[3].unlocked)
            {
                GetComponent<PlayerMovement>().gravity *= 5.0f;
                FastFall = true;
            }//Ground Pound

            Block(); 
        }

        private void AttackInteract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            AC.AttackAniTrigger();

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

        public void FinishingAttackCollision()
        {
            Collider[] colliders = Physics.OverlapSphere(AttackPoint.position, AttackRange, EnemyLayer);

            foreach (Collider col in colliders)
            {
                if (col.tag == "Enemy")
                {
                    Attack(AttackDamage, col.gameObject); 
                    Vector3 KnockbackDirection = (AttackPoint.position - col.transform.position) * -1;
                    GetComponent<EntityMovement>().KnockbackCalc(col.GetComponent<EntityMovement>(),
                        KnockbackDirection);
                }

                if (col.tag == "Breakable")
                    Destroy(col.gameObject); //Placeholder for the scripted destruction of said object
            }

        }//A "combo finisher" that knocks the enemy back and does more damage

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
            } // Card autolocks to the closest enemy
            else
            {
                CardLockOn.localPosition = CardReturnPostion; 
            }//if nothing in range it just goes forward

            if(TimeLeftToContinueComboString <= 0)
            {
                combo = 0;
                AC.ComboNumber(combo);
            }//resets combo
            else
            {
                TimeLeftToContinueComboString -= Time.deltaTime; 
            }//Counts down combo 

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
        }//Player takes damage. If the player has 0 or less health they die.
        //Blocking keeps player from taking damage

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