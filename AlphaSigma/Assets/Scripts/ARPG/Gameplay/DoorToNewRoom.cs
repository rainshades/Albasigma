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
            TeleportRoom.SetActive(true);

            yield return new WaitForSecondsRealtime(time);
            transform.GetComponentInParent<ArenaManager>().gameObject.SetActive(false);
            
            PC.transform.position = TeleportSpace.transform.position;
        }//TeleportsPlayer
    }
}