using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

namespace Albasigma.ARPG
{
    public class DummyRangedCombatMovement : MonoBehaviour, IEnemyAIDetection
    {

        GameObject Target;
        bool canRunAway; 
        bool PlayerInRange;
        public float DetectionRange;
        public LayerMask PlayerLayer;
        [SerializeField]
        SpriteRenderer Detected;
        public NavMeshAgent agent;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>(); 
        }

        public void LoseDetection()
        {
            Target = null;
            Detected.gameObject.SetActive(false);
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
            canRunAway = Vector3.Distance(transform.position, Target.transform.position) < 4 && !GetComponent<DummyRangedCombat>().RecentlyFired;
        }

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

            if (canRunAway)
            {
                agent.Move(Vector3.back * Time.deltaTime * 2.5f);
            }
        }
    }
}