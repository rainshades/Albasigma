using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albasigma.ARPG
{

    public enum MoveState { Idle, Jumping, Falling, Running }

    public class PlayerMovement : EntityMovement
    {
        public PlayerControls inputs;

        [SerializeField]
        GameObject PlayerGFX;

        public float jumpHeight;
        float baseJumpHeight; 
        
        Vector3 MovementAngle;

        int jumpcounter = 0; 

        private void Awake()
        {
            inputs = new PlayerControls();

            baseJumpHeight = jumpHeight; 

            inputs.Player.Jump.started += Jump_performed;
            inputs.Player.Jump.canceled += ctx => moveState = MoveState.Falling; 
            inputs.Player.Movement.started += Movement_performed;
            inputs.Player.Movement.performed += Movement_performed;
            inputs.Player.Movement.canceled += Movement_canceled;
        }

        protected override void GravityCheck()
        {
            base.GravityCheck();
            if(!grounded && JumpForce.y <= 0)
            {
                JumpForce.y = Mathf.Sqrt(jumpHeight * gravity) * -1;
            }

            if(moveState != MoveState.Jumping)
            {
                JumpForce.y -= gravity * Time.deltaTime; 
            }

            if(grounded && moveState != MoveState.Running)
            {
                moveState = MoveState.Idle; 
            }

            if (grounded)
            {
                gravity = baseGravity;
                jumpcounter = 0;
                jumpHeight = baseJumpHeight; 
            }
        }


        private void Movement_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            MovementForce = Vector3.zero; 
        }

        private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if ((grounded && moveState != MoveState.Jumping) || (!grounded && jumpcounter < 2 && moveState != MoveState.Jumping))
            {
                jumpcounter++;
                if (jumpcounter == 0)
                {
                    JumpForce.y = Mathf.Sqrt(jumpHeight * gravity) * 2;
                    moveState = MoveState.Jumping;
                }
                else if(jumpcounter == 1)
                {
                    jumpHeight /= 2;

                    JumpForce.y = Mathf.Sqrt(jumpHeight * gravity) * 2;
                    moveState = MoveState.Jumping;
                } 
                else if(jumpcounter == 2)
                {
                    gravity = 1.0f;
                } 
            }
        }

        private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            targetAngle = Mathf.Atan2(MovementAngle.x, MovementAngle.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            MovementForce = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            MovementAngle = new Vector3(obj.ReadValue<Vector2>().x, 0, obj.ReadValue<Vector2>().y);
            Vector3 NormalizedMovement = MovementAngle.normalized;
            MovementAngle = NormalizedMovement; 
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