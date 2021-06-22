using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albasigma.ARPG
{
    public class PlayerMovement : MonoBehaviour
    {
        public PlayerControls inputs;
        public float MovementSpeed; 
        CharacterController cc;

        Vector3 MovementForce = Vector3.zero;

        [SerializeField]
        GameObject PlayerGFX; 

        private void Awake()
        {
            cc = GetComponent<CharacterController>(); 
            inputs = new PlayerControls();

            inputs.Player.Jump.performed += Jump_performed;


            inputs.Player.Movement.started += Movement_performed;
            inputs.Player.Movement.performed += Movement_performed;
            inputs.Player.Movement.canceled += Movement_canceled;
        }

        private void Update()
        {
        }

        private void FixedUpdate()
        {   
            cc.Move(MovementForce * MovementSpeed * Time.deltaTime );
        }

        private void Movement_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            MovementForce = Vector3.zero; 
        }

        private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            throw new System.NotImplementedException();
        }

        private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Vector3 MovementAngle = new Vector3(obj.ReadValue<Vector2>().x, transform.position.y, obj.ReadValue<Vector2>().y);

            Vector3 NormalizedMovement = MovementAngle.normalized;

            float rotation = 0;

            if (MovementAngle.z > 0)
                rotation = 0;
            else if (MovementAngle.z < 0)
                rotation = 180;

            if (MovementAngle.x > 0)
                rotation = 90;
            else if (MovementAngle.x < 0)
                rotation = 270;

            PlayerGFX.transform.eulerAngles = new Vector3(PlayerGFX.transform.eulerAngles.x, rotation, PlayerGFX.transform.eulerAngles.z); 

            MovementForce = NormalizedMovement; 
        }

        private void OnEnable()
        {
            inputs.Enable(); 
        }

        private void OnDisable()
        {
            inputs.Disable(); 
        }
    }
}