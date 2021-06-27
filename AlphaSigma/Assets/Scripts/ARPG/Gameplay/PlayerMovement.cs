using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albasigma.ARPG
{

    public class EntityMovement : MonoBehaviour
    {
        protected MoveState moveState;

        public float MovementSpeed;
        protected CharacterController cc;
        
        [SerializeField]
        protected GameObject BottomPoint;

        [SerializeField]
        protected LayerMask GroundedLayer;

        public float gravity;
        protected Vector3 JumpForce; 
        public bool grounded = true;

        [SerializeField]
        float distanceGrounded = 0.01f;

        protected float angle, targetAngle, turnSmoothVelocity;
        public float turnSmoothTime = 0.1f;

        protected Vector3 MovementForce = Vector3.zero;

        private void Start()
        {

            cc = GetComponent<CharacterController>();

            if(cc == null)
            {
                gameObject.AddComponent<CharacterController>(); 
            }

            if (BottomPoint == null)
            {
                BottomPoint = Instantiate(new GameObject(), transform);
                BottomPoint.transform.localPosition = Vector3.zero;
            }
        }


        protected virtual void GravityCheck()
        {
            grounded = Physics.CheckSphere(BottomPoint.transform.position, distanceGrounded, GroundedLayer);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(BottomPoint.transform.position, distanceGrounded);
        }


        private void FixedUpdate()
        {
            GravityCheck();
            cc.Move(JumpForce * MovementSpeed * Time.deltaTime);

            cc.Move(MovementForce * MovementSpeed * Time.deltaTime);
        }

    }

    public enum MoveState { Idle, Jumping, Falling, Running }

    public class PlayerMovement : EntityMovement
    {
        public PlayerControls inputs;

        [SerializeField]
        GameObject PlayerGFX;

        public float jumpHeight; 

        private void Awake()
        {
            inputs = new PlayerControls();

            inputs.Player.Jump.started += Jump_performed;

            inputs.Player.Movement.started += Movement_performed;
            inputs.Player.Movement.performed += Movement_performed;
            inputs.Player.Movement.canceled += Movement_canceled;
        }

        protected override void GravityCheck()
        {
            base.GravityCheck();
            if(!grounded && MovementForce.y <= 0)
            {
                JumpForce.y = Mathf.Sqrt(jumpHeight * gravity) * -1;
                moveState = MoveState.Falling; 
            }

            if(moveState != MoveState.Jumping)
            {
                JumpForce.y -= gravity * Time.deltaTime; 
            }
        }


        private void Movement_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            MovementForce = Vector3.zero; 
        }

        private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if(grounded && moveState != MoveState.Jumping)
                JumpForce.y = jumpHeight; 

        }

        private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Vector3 MovementAngle = new Vector3(obj.ReadValue<Vector2>().x, 0 ,obj.ReadValue<Vector2>().y);

            Vector3 NormalizedMovement = MovementAngle.normalized;


            targetAngle = Mathf.Atan2(MovementForce.x, MovementForce.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            PlayerGFX.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            MovementForce = NormalizedMovement; 
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