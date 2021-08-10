using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Albasigma.ARPG;
using UnityEngine.InputSystem; 

namespace Albasigma.UI
{
    public class SkillMenu : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI ManaText;

        [SerializeField]
        GameObject SkillMenuPrefab;

        [SerializeField]
        SkillList PlayerSkill;

        [SerializeField]
        PlayerStats Stats; 

        Transform ContentPanel;

        PlayerControls pc;
        int index = 0;
        List<SkillUIObject> Skills = new List<SkillUIObject>();
        SkillUIObject CurrentSelection;

        private void Awake()
        {
            pc = new PlayerControls();

            pc.UI.MenuMove.performed += MenuMove_performed;

        }

        private void Update()
        {
            CurrentSelection = Skills[index];
            CurrentSelection.Selected = true; 

            ManaText.text = Stats.currentMana + "/" + Stats.Mana;

            if (Gamepad.current.buttonSouth.wasReleasedThisFrame)
            {
                SelectSkill(CurrentSelection);
            }
        }

        private void MenuMove_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Vector2 indexmover = obj.ReadValue<Vector2>();
            CurrentSelection.Selected = false; 
            if ((indexmover.x > 0 || indexmover.y > 0) && index > 0)
            {
                index--;
            }
            else if ((indexmover.x < 0 || indexmover.y < 0) && index < Skills.Count - 1)
            {
                index++;
            }// cycling through the shop

        }


        void SelectSkill(SkillUIObject SkillObject)
        {
            if (SkillObject.Skill.unlocked)
            {
                SkillObject.Skill.unlocked = false;
                Stats.currentMana += SkillObject.Skill.ManaCost;
                SkillObject.ToggleChild.isOn = false; 
            }
            else if(SkillObject.Skill.ManaCost <= Stats.currentMana)
            {
                SkillObject.Skill.unlocked = true;
                SkillObject.ToggleChild.isOn = true;
                Stats.currentMana -= SkillObject.Skill.ManaCost; 
            }

            PlayerSkill.Skills[index] = SkillObject.Skill; 
        }

        private void OnEnable()
        {
            pc.Enable(); 

            ContentPanel = transform.GetChild(1).GetChild(0).GetChild(0);
            foreach(SkillList.Skill skill in PlayerSkill.Skills)
            {
                SkillUIObject go = Instantiate(SkillMenuPrefab, ContentPanel).GetComponent<SkillUIObject>();

                go.Skill = skill;
                go.ToggleChild.isOn = skill.unlocked;
                go.ToggleChild.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = skill.name;

                Skills.Add(go); 
            }
            Skills[0].Selected = true; 
        }

        private void OnDisable()
        {
            pc.Disable(); 
            for(int i = 0; i < ContentPanel.childCount; i++)
            {
                Destroy(ContentPanel.GetChild(i).gameObject);
            }
        }
    }
}