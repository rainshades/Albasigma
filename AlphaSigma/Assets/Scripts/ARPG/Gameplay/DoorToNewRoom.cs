using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    /// <summary>
    /// Teleport's player to a new location and turns on the arena at the destination 
    /// </summary>
    public class DoorToNewRoom : MonoBehaviour
    {
        bool open; //if the player is allowed to open the door

        [SerializeField]
        GameObject TeleportRoom, TeleportSpace; 
        //Room to teleport to
        //Space to teleport to in that room

        public IEnumerator GoTo(PlayerInteractionController PC, float time)
        {
            yield return new WaitForSecondsRealtime(time);
            
            TeleportRoom.SetActive(true);

            transform.GetComponentInParent<ArenaManager>().gameObject.SetActive(false);
            
            PC.transform.position = TeleportSpace.transform.position;
            PC.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180); 
                        
        }//TeleportsPlayer

        private void OnDrawGizmos()
        {
            try {
                Gizmos.DrawWireSphere(transform.GetChild(0).position, 1.0f);
            }
            catch
            {

            }
        }
    }
}