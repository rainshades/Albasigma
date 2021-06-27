using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

namespace Albasigma
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; set;  }

        Albasigma.UI.PlayerPuaseUI pauseUI; 

        public bool Paused;

        PlayerControls pc; 
        private void Awake()
        {
            pc = new PlayerControls(); 
            Instance = this;
            pc.Player.Pause.performed += Pause_performed;
            pauseUI = FindObjectOfType<Albasigma.UI.PlayerPuaseUI>(); 
        }

        private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Paused = true;
            pauseUI.gameObject.SetActive(Paused); 
        }

        public void GameOver()
        {
            SceneManager.LoadScene(0);
        }

        private void OnEnable()
        {
            pc.Enable(); 
        }

        private void OnDisable()
        {
            pc.Disable(); 
        }
    }
}