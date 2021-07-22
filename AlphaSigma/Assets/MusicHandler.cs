using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.ARPG; 

namespace Albasigma
{
    public class MusicHandler : MonoBehaviour
    {
        [SerializeField]
        AudioClip NonCombatTheme;
        [SerializeField]
        AudioClip CombatTheme; 

        AudioSource Source; 


        // Start is called before the first frame update
        void Start()
        {
            Source = GetComponent<AudioSource>();
            if (!GetComponentInParent<ArenaManager>().AllEnemiesDefeated && NonCombatTheme != null)
            {
                Source.clip = NonCombatTheme;
                Source.Play();
            }
            else if(GetComponentInParent<ArenaManager>().AllEnemiesDefeated && CombatTheme != null)
            {
                Source.clip = CombatTheme;
                Source.Play(); 
            }
        }
    }
}