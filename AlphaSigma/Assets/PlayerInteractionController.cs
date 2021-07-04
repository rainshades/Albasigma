using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    public class PlayerInteractionController : MonoBehaviour
    {
        public LayerMask InteractableLayers;
        public float interactionRange;
        public IInteractable CurrentInteractable;
        SpriteRenderer InInteractableInRange;

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, interactionRange); 
        }

        private void Awake()
        {
            interactionRange = GetComponent<PlayerCombat>().AttackRange;
            InInteractableInRange = GetComponentInChildren<SpriteRenderer>(); 
        }

        private void FixedUpdate()
        {

                Collider[] col = Physics.OverlapSphere(transform.position, interactionRange, InteractableLayers);

            if (col.Length > 0)
                CurrentInteractable = col[0].GetComponentInParent<IInteractable>();
            else
                CurrentInteractable = null; 

            if (CurrentInteractable != null)
            {
                InInteractableInRange.gameObject.SetActive(true);
            }
            else
            {
                InInteractableInRange.gameObject.SetActive(false);
            }
        }
    }
}