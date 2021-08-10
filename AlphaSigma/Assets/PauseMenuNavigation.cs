using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem; 

namespace Albasigma.UI
{
    public class PauseMenuNavigation : MonoBehaviour
    {
        int index = 0;

        [SerializeField]
        Button CloseButton; 

        [SerializeField]
        List<Button> MenuButtons;

        Button CurrentButton;

        PlayerControls inputs;

        private void Awake()
        {
            inputs = new PlayerControls();

            inputs.UI.MenuMove.performed += MenuMove_performed;
        }


        private void MenuMove_performed(InputAction.CallbackContext obj)
        {
            Vector2 indexmover = obj.ReadValue<Vector2>();

            if ((indexmover.x > 0 || indexmover.y > 0) && index > 0)
            {
                index--;
            }
            else if ((indexmover.y < 0 || indexmover.y < 0) && index < transform.childCount - 1)
            {
                index++;
            }// cycling through the shop
        }

        private void Update()
        {
            CurrentButton = MenuButtons[index];

            if (Gamepad.current.buttonSouth.wasReleasedThisFrame)
            {
                CurrentButton.onClick.Invoke();
            }

            if (Gamepad.current.buttonEast.wasReleasedThisFrame)
            {
                CloseButton.onClick.Invoke();
            }
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