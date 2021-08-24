using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine; 

namespace Albasigma.ARPG
{

    public enum MoveState { Idle, Jumping, Falling, Running }

    /// <summary>
    /// Handles Player movement options 
    /// </summary>
    public class PlayerMovement : EntityMovement
    {
        [SerializeField]
        SkillList Skills;

        public PlayerControls inputs;
        public PlayerAnimationController AC;

        public PlayerCombat combat; 

        [SerializeField]
        GameObject PlayerGFX;

        public float jumpHeight;
        float baseJumpHeight; 
        
        Vector3 MovementAngle;

        int jumpcounter = 0;
        //Meant to convey jump status
        //Jump 1 = Innitial Jump
        //Jump 2 = Secondary Jump
        //Jump 3 = Flight

        [SerializeField]
        GameObject PlayerLedgePoint;

        bool OnLedge;

        Vector3 LedgeBoxSize = new Vector3(0.25f, 0.25f, 0.25f);

        Ledge activeLedge; 
                

        private void Awake()
        {
            inputs = new PlayerControls();

            baseJumpHeight = jumpHeight;

            AC = GetComponent<PlayerAnimationController>();
            combat = GetComponent<PlayerCombat>();

            inputs.Player.Jump.started += Jump_performed;
            inputs.Player.Jump.canceled += ctx => moveState = MoveState.Falling; 
            inputs.Player.Movement.started += Movement_performed;
            inputs.Player.Movement.performed += Movement_performed;
            inputs.Player.Movement.canceled += Movement_canceled;

            if(Gamepad.current != null)
            {
                CinemachineFreeLook freeLook = FindObjectOfType<CinemachineFreeLook>();
                
                freeLook.m_XAxis.m_InputAxisName = "";
                freeLook.m_YAxis.m_InputAxisName = "";
            }
            else
            {
                CinemachineFreeLook freeLook = FindObjectOfType<CinemachineFreeLook>();
                freeLook.m_XAxis.m_InputAxisName = "Mouse X";
                freeLook.m_YAxis.m_InputAxisName = "Mouse Y";
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(PlayerLedgePoint.transform.position, LedgeBoxSize);
        }

        protected override void GravityCheck()
        {
            base.GravityCheck();

            if(KnockbackCounter <= 0)
            {
                JumpForce.x = 0;
                JumpForce.z = 0; 
            }//No nock back resets the jumpforce movement 
            if(!grounded && JumpForce.y <= 0)
            {
                JumpForce.y = Mathf.Sqrt(jumpHeight * gravity) * -1;
            }//Jump innertia 

            if(moveState != MoveState.Jumping && !grounded)
            {
                JumpForce.y -= gravity * Time.deltaTime; 
            }//Falling

            if(grounded && moveState != MoveState.Running)
            {
                moveState = MoveState.Idle; 
            }//Movestate reset

            if (grounded)
            {
                combat.FastFall = false;

                gravity = baseGravity;
                jumpcounter = 0;
                jumpHeight = baseJumpHeight;
                CurrentMovementSpeed = baseMovementSpeed;
            }
            else if(OnLedge)
            {
                if (!AC.animator.GetCurrentAnimatorStateInfo(0).IsName("LedgeGrab"))
                {
                    AC.animator.Play("LedgeGrab");
                }

               StopMovement();
               JumpForce = Vector3.zero;
               gravity = 0;
            }//ledge grab 
            
            AC.isGrounded(grounded); //GroundCheck
        }

        protected override void KnockBack(Vector3 Direction)
        {
            base.KnockBack(Direction);
            if (!combat.Blocking)
            {
                JumpForce = Direction * KnockbackForce * 4;
                JumpForce.y = KnockbackForce * 1.5f;
            }//If a player is not blocking an attack they get knocked back
        }

        private void Movement_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            StopMovement(); 
        }

        public void StopMovement()
        {
            MovementForce = Vector3.zero;
            AC.StopRunning();
        }

        private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (!combat.Blocking && !combat.Attacking)
            {
                if ((grounded && moveState != MoveState.Jumping) || (!grounded && jumpcounter < 2 && moveState != MoveState.Jumping))
                {
                    jumpcounter++;
                    if (jumpcounter == 0)
                    {
                        JumpForce.y = Mathf.Sqrt(jumpHeight * gravity) * 2;
                        moveState = MoveState.Jumping;
                    }//first jump
                    else if (jumpcounter == 1)
                    {
                        JumpForce.y = Mathf.Sqrt(jumpHeight * gravity) * 2;
                    }//second jump
                                                    //Flight
                    else if (jumpcounter >= 2 && Skills.Skills[7].unlocked)
                    {
                        CurrentMovementSpeed *= combat.Stats.FlightSpeed; 
                        AC.GlideTrigger();
                    }//flight
                }
            }

            if (OnLedge)
            {
                AC.UpFromLedge();
            }
        }//Jump Y-Movement

        private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (!combat.Blocking && !combat.Attacking && !OnLedge)
            {
                targetAngle = Mathf.Atan2(MovementAngle.x, MovementAngle.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
                //Calculating the forward angle by using the tangent of the Camera y-axis 
                angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); 
                //Smoothing the angle 
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                //Rotates the character towards the smoothed angle 
                MovementForce = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                MovementAngle = new Vector3(obj.ReadValue<Vector2>().x, 0, obj.ReadValue<Vector2>().y);
                Vector3 NormalizedMovement = MovementAngle.normalized;
                MovementAngle = NormalizedMovement;

                if (!AC.isRunning)
                {
                    AC.StartRunning();
                }
            }
            else if (OnLedge)
            {
                AC.UpFromLedge();
            }
            else
            {
                StopMovement(); 
            }

        }//Move X-, Z-Movement

        protected override bool LedgeCheck()
        {
            bool hitledge = false;

            if (!OnLedge)
            {
                Collider[] colliders = Physics.OverlapBox(PlayerLedgePoint.transform.position, LedgeBoxSize / 2);
                foreach (Collider col in colliders)
                {
                    hitledge = col.tag == "Ledge";
                    if (hitledge)
                    {
                        activeLedge = col.GetComponent<Ledge>();
                        OnLedge = true; 
                    }
                }
            }
            return hitledge; 
        }

        public void Lunge()
        {
                //Lunge
            if (Skills.Skills[6].unlocked)
            {
                cc.Move(Vector3.forward);
            }
        }//Lunges the player forward if they've unlocked the ability 

        public void ClimbUpFromLedge()
        {
            transform.position = activeLedge.GetStandUpPos();
            OnLedge = false; 
        }//sets the position as the climb up 

        public void Enable()
        {
            inputs.Enable();
        }

        public void Disable()
        {
            inputs.Disable();
        }

        private void OnEnable()
        {
            inputs.Enable();
        }

        private void OnDisable()
        {
            inputs.Disable();
        }
    }
}