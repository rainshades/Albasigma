using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

namespace Albasigma.ARPG
{
    public interface IEnemyAIDetection
    {
        public void OnDetection();// On the detection of the player or Another object. AI must distingush what it needs to detect in it's own script
        public void LoseDetection();//What happens when an object is out of its detection range
    }
    

    public class DummyMovement : EntityMovement, IEnemyAIDetection
    {
        GameObject Target;
        bool PlayerInRange;
        public float DetectionRange; 
        public LayerMask PlayerLayer;
        [SerializeField]
        SpriteRenderer Detected;
        public NavMeshAgent agent;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();// agent assignment
        }

        protected override void GravityCheck()
        {
            base.GravityCheck();

            if (KnockbackCounter <= 0)
            {
                JumpForce.x = 0;
                JumpForce.z = 0;
            }//No nock back resets the jumpforce movement 

        }

        private void Update()
        {
            if (KnockbackCounter > 0)
            {
                agent.velocity = JumpForce * Time.deltaTime * KnockbackForce;
                KnockbackCounter -= Time.deltaTime;
            }
        }

        private void FixedUpdate()
        {
            PlayerInRange = Physics.CheckSphere(transform.position, DetectionRange, PlayerLayer);

            GravityCheck();

            if (PlayerInRange && KnockbackCounter <= 0)
            {
                OnDetection();
            }//Activate if player is in range
            else
            {
                LoseDetection();
            }//Deactivation 

            if(Target != null)
            {
                transform.LookAt(new Vector3(Target.transform.position.x, 0, Target.transform.position.z));  
            }// helps determined the forward by looking at the player
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, DetectionRange);
        }

        public void OnDetection()
        {
            Collider[] col = Physics.OverlapSphere(transform.position, DetectionRange, PlayerLayer);
            Target = col[0].gameObject;
            Detected.gameObject.SetActive(true);
            agent.SetDestination(new Vector3(Target.transform.position.x - 0.5f, Target.transform.position.y, Target.transform.position.z - 1.5f));
            //Destination is meant to stop right in front of the player
        }//Happens when the selected object is detected

        protected override void KnockBack(Vector3 Direction)
        {
            base.KnockBack(Direction);
            JumpForce = Direction * KnockbackForce * 4;
            JumpForce.y = KnockbackForce * 1.5f;
            JumpForce.x *= -1;
            JumpForce.z *= -1; 
        }

        public void LoseDetection()
        {
            Target = null;
            Detected.gameObject.SetActive(false); 
        }//When player leaves detection range

    }
}