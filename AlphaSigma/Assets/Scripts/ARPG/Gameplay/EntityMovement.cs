using UnityEngine;


namespace Albasigma.ARPG
{
    public class EntityMovement : MonoBehaviour
    {
        protected MoveState moveState;
        [HideInInspector]
        public float CurrentMovementSpeed;
        [SerializeField]
        protected float baseMovementSpeed; 
        protected CharacterController cc;
        
        [SerializeField]
        protected GameObject BottomPoint;

        [SerializeField]
        protected LayerMask GroundedLayer;

        public float gravity;
        protected float baseGravity;  
        protected Vector3 JumpForce; 
        public bool grounded = true;

        [SerializeField]
        float distanceGrounded = 0.01f;

        protected float angle, targetAngle, turnSmoothVelocity;
        public float turnSmoothTime = 0.1f;

        public float KnockbackForce;
        public float KnockbackTimer;
        protected float KnockbackCounter;

        protected Vector3 MovementForce = Vector3.zero;

        private void Start()
        {
            CurrentMovementSpeed = baseMovementSpeed;
            baseGravity = gravity;
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

        protected virtual void KnockBack(Vector3 Direction)
        {
            KnockbackCounter = KnockbackTimer;
        }

        public void KnockbackCalc(EntityMovement target, Vector3 direction)
        {
            target.KnockBack(direction);
        }


        private void FixedUpdate()
        {
            GravityCheck();

            cc.Move(JumpForce * Time.deltaTime * 2.0f);

            if (KnockbackCounter <= 0)
            {
                cc.Move(MovementForce * CurrentMovementSpeed * Time.deltaTime);
            }
            else
            {
                KnockbackCounter -= Time.deltaTime; 
            }
        }

    }
}