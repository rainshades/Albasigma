using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    public class DoorToNewRoom : MonoBehaviour
    {
        [SerializeField]
        GameObject TeleportRoom, TeleportSpace; 

        public void GoTo(PlayerInteractionController PC)
        {
            transform.parent.gameObject.SetActive(false);
            TeleportRoom.SetActive(true);

            PC.transform.position = TeleportSpace.transform.position;
        }
    }
}