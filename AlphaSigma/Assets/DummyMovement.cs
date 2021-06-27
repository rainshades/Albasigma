using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albasigma.ARPG
{
    public interface IEnemyAIDetection
    {
        public void OnDetection();
        public void LoseDetection();
    }
    

    public class DummyMovement : EntityMovement, IEnemyAIDetection
    {
        GameObject Target; 

        bool PlayerInRange;
        public float DetectionRange; 
        public LayerMask PlayerLayer;
        [SerializeField]
        SpriteRenderer Detected; 

        private void FixedUpdate()
        {
            PlayerInRange = Physics.CheckSphere(transform.position, DetectionRange, PlayerLayer);
            if (PlayerInRange)
            {
                OnDetection();
            }
            else
            {
                LoseDetection(); 
            }

            if(Target != null)
            {
                transform.LookAt(Target.transform);  
            }
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
        }

        public void LoseDetection()
        {
            Target = null;
            Detected.gameObject.SetActive(false); 
        }
    }
}