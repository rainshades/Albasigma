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
            try
            {
                Ally_1.sprite = Deck.DeckSO.Ally_1.AllyImage; Ally_2.sprite = Deck.DeckSO.Ally_2.AllyImage;
            }
            catch
            {
                if(Deck.DeckSO.Ally_1 == null)
                {
                    Ally_1.gameObject.SetActive(false); 
                }
                if (Deck.DeckSO.Ally_2 == null)
                {
                    Ally_2.gameObject.SetActive(false);
                }

            }
        }
    }
}