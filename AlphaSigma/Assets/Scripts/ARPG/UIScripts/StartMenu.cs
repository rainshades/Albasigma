using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

namespace Albasigma.UI
{
    public class StartMenu : MonoBehaviour
    {
        public void StartNewGame()
        {
            SceneManager.LoadScene(2);
        }

        public void CloseGame()
        {
            Application.Quit(); 
        }
    }
}