using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Albasigma.ARPG; 

namespace Albasigma.UI
{
    public class AlliesUI : MonoBehaviour
    {
        [SerializeField]
        Image Ally_1, Ally_2; 

        DeckOfCards Deck;

        private void Awake()
        {
            Deck = FindObjectOfType<DeckOfCards>();
            Ally_1.sprite = Deck.Ally_1.AllyImage; Ally_2.sprite = Deck.Ally_2.AllyImage; 
        }
    }
}