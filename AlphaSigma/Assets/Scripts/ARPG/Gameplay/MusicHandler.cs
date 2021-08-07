using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.ARPG; 

namespace Albasigma
{    /// <summary>
    /// Handles music 
    /// This is not meant for other types of audio
    /// </summary>
    public class MusicHandler : MonoBehaviour
    {
        [SerializeField]
        AudioClip NonCombatTheme;
        [SerializeField]
        AudioClip CombatTheme; 
        AudioSource Source;

        public static ArenaManager ArenaManager; 
        //Needed to allow ArenaManager to be assigned whenver an arenamanager
        //becomes active without having to find the object or use it as a sigleton 

        private void Awake()
        {
            Source = GetComponent<AudioSource>();
        }

        // Start is called before the first frame update
        void Update()
        {
            if (ArenaManager.AllEnemiesDefeated && NonCombatTheme != null && Source.clip != NonCombatTheme)
            {
                Source.clip = NonCombatTheme;
                Source.Play();
            }//Play non combat theme
            else if(!ArenaManager.AllEnemiesDefeated && CombatTheme != null && Source.clip != CombatTheme)
            {
                Source.clip = CombatTheme;
                Source.Play(); 
            }//Play combat theme
        }
    }
}