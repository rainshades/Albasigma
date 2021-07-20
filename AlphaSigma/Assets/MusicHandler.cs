using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma
{
    public class MusicHandler : MonoBehaviour
    {
        [SerializeField]
        AudioClip backgroundAudio;

        AudioSource Source; 


        // Start is called before the first frame update
        void Start()
        {
            Source = GetComponent<AudioSource>();
            if (backgroundAudio != null)
            {
                Source.clip = backgroundAudio;
                Source.Play();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}