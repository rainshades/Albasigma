using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Albasigma.Cards;
using UnityEngine.UI; 

namespace Albasigma.UI
{
    public class UICardObject : MonoBehaviour
    {
        [SerializeField]
        Image Cardimage;
        TextMeshProUGUI CardCost;
        [SerializeField]
        SpellCard Spell;

        private void Awake()
        {
            CardCost = GetComponentInChildren<TextMeshProUGUI>(); 

            if(Spell == null)
            {
                gameObject.SetActive(false);
            }
            else
            {
                SetCard(Spell); 
            }
        }

        public void SetCard(SpellCard spell)
        {

            if (spell == null)
            {
                Spell = null; 
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
                Spell = spell;
                Cardimage.sprite = spell.Image;
                CardCost.text = "" + spell.cost;
            }
        }
    }
}