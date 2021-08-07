using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

namespace Albasigma.ARPG
{
    /// <summary>
    /// Ranged movement for the combat dummy
    /// </summary>
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
                //Trying to give the player a little time to hit the dummy before it runs backwards
        }//On detection makes player a target and decides whether or not it wants to run away

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
            }//if it hasn't fired recently it runs away
            
        }
    }
}