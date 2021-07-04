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
        protected float baseGravity;  
        protected Vector3 JumpForce; 
        public bool grounded = true;

        [SerializeField]
        float distanceGrounded = 0.01f;

        protected float angle, targetAngle, turnSmoothVelocity;
        public float turnSmoothTime = 0.1f;

        protected Vector3 MovementForce = Vector3.zero;

        private void Start()
        {
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


        private void FixedUpdate()
        {
            GravityCheck();
            cc.Move(JumpForce * Time.deltaTime * 2.0f);

            cc.Move(MovementForce * MovementSpeed * Time.deltaTime);
        }

    }
}