using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Albasigma
{
    [RequireComponent(typeof(CinemachineFreeLook))]
    public class FreeLookAddOn : MonoBehaviour
    {
        [Range(0f, 10f)] public float LookSpeed = 1f;
        public bool InvertY = false;
        private CinemachineFreeLook _freeLookComponent;

        public void Start()
        {
            _freeLookComponent = GetComponent<CinemachineFreeLook>();
        }

        // Update the look movement each time the event is trigger
        public void OnLook(InputAction.CallbackContext context)
        {
            //Normalize the vector to have an uniform vector in whichever form it came from (I.E Gamepad, mouse, etc)
            Vector2 lookMovement = context.ReadValue<Vector2>().normalized;
            lookMovement.y = InvertY ? -lookMovement.y : lookMovement.y;

            // This is because X axis is only contains between -180 and 180 instead of 0 and 1 like the Y axis
            lookMovement.x = lookMovement.x * 180f;

            //Ajust axis values using look speed and Time.deltaTime so the look doesn't go faster if there is more FPS
            _freeLookComponent.m_XAxis.Value += lookMovement.x * LookSpeed * Time.deltaTime;
            _freeLookComponent.m_YAxis.Value += lookMovement.y * LookSpeed * Time.deltaTime;
        }
    }
}