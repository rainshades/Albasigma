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
        bool open; 

        [SerializeField]
        GameObject TeleportRoom, TeleportSpace; 
        //Room to teleport to
        //Space to teleport to in that room

        public void GoTo(PlayerInteractionController PC)
        {
            transform.parent.gameObject.SetActive(false);
            TeleportRoom.SetActive(true);

            PC.transform.position = TeleportSpace.transform.position;
        }//TeleportsPlayer
    }
}