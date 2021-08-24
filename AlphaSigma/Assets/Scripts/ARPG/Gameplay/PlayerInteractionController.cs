using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    /// <summary>
    /// Handles how player interacts with Iinteractalbes and 
    /// other game objects (i.e. Doors/teleporters)
    /// </summary>
    public class PlayerInteractionController : MonoBehaviour
    {
        public LayerMask InteractableLayers;
        public float interactionRange;
        public IInteractable CurrentInteractable;
        public bool InInteractableInRange; 

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, interactionRange); 
        }

        private void Awake()
        {
            interactionRange = GetComponent<PlayerCombat>().AttackRange;
        }

        private void FixedUpdate()
        {
            Collider[] col = Physics.OverlapSphere(transform.position, interactionRange, InteractableLayers);
            InInteractableInRange = col.Length > 0; 

            if (InInteractableInRange)
                CurrentInteractable = col[0].GetComponentInParent<IInteractable>();

            else
                CurrentInteractable = null; 
        }


        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Door")
            {
                other.GetComponent<DoorToNewRoom>().GoTo(this); 
            }

            if(other.TryGetComponent(out ThreshHold TH)){
                TH.ActivateThreshhold(); 
            }

        }

    }
}