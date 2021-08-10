using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.ARPG;
using UnityEngine.UI;

namespace Albasigma.UI {
    public class SkillUIObject : MonoBehaviour
    {
        public Toggle ToggleChild;
        public SkillList.Skill Skill;

        public bool Selected;
        public Image SelectedImage; 

        private void Awake()
        {
            ToggleChild = GetComponentInChildren<Toggle>(); 
        }

        private void Update()
        {
            SelectedImage.gameObject.SetActive(Selected); 
        }
    }
}