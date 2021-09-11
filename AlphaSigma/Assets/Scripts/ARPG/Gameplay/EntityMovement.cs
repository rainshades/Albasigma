using UnityEngine;

namespace Albasigma.ARPG
{
    /// <summary>
    /// Base movement for standard movement objects that use Character Controller
    /// </summary>
    public class EntityMovement : MonoBehaviour
    {
        protected MoveState moveState; //Current movestate
        [HideInInspector]
        public float CurrentMovementSpeed; //Movementspeed after imparements or inhancements
        [SerializeField]
        protected float baseMovementSpeed; 
        protected CharacterController cc;
        
        [SerializeField]
        protected GameObject BottomPoint; // Point that determins ground collision

        [SerializeField]
        protected LayerMask GroundedLayer;

        public float gravity; //Gravity after imparements or inhacements
        protected float baseGravity;  
        protected Vector3 JumpForce; //Force used to interact with the Y-axis
        public bool grounded = true;

        [SerializeField]
        protected Vector3 distanceGrounded;

        protected float angle, targetAngle, turnSmoothVelocity;
        public float turnSmoothTime = 0.1f;

        public float KnockbackForce;
        public float KnockbackTimer;
        protected float KnockbackCounter;

        protected Vector3 MovementForce = Vector3.zero;//Force used to interact with the X-,Z-Axis
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
            } // Creates a bottom point if one is not currently asigned at the base of the entity object 
        }


        protected virtual void GravityCheck()
        {
            grounded = Physics.CheckBox(BottomPoint.transform.position, distanceGrounded, Quaternion.identity, GroundedLayer);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(BottomPoint.transform.position, distanceGrounded);
        }

        protected virtual void KnockBack(Vector3 Direction)
        {
            KnockbackCounter = KnockbackTimer;
        }

        public void KnockbackCalc(EntityMovement target, Vector3 direction)
        {
            target.KnockBack(direction);
        }

        protected virtual bool LedgeCheck()
        {
            return false; 
        }

        private void FixedUpdate()
        {
            GravityCheck();

            cc.Move(JumpForce * Time.deltaTime * 2.0f);//Player verticle movement
            if (KnockbackCounter <= 0)
            {
                cc.Move(MovementForce * CurrentMovementSpeed * Time.deltaTime);
                //Player moves when able
                //Things that would impair player movement at the moment
                //Knockback
            }
            else
            {
                KnockbackCounter -= Time.deltaTime; 
            }//when Knockback is greater than 
        }

    }
}