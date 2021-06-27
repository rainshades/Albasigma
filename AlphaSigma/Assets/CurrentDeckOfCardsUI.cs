using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using Albasigma.ARPG;
using Albasigma.Cards; 

namespace Albasigma.UI
{
    public class CurrentDeckOfCardsUI : MonoBehaviour
    {
        DeckOfCards Deck;

        [SerializeField]
        GameObject SelectedCard;
        [SerializeField]
        List<GameObject> Cards = new List<GameObject>();

        int selectedCardIndex = 0;

        PlayerControls pc;

        private void Awake()
        {
            pc = new PlayerControls();

            pc.UI.MenuMove.performed += MenuMove_performed;

            Deck = FindObjectOfType<DeckOfCards>(); 

            foreach(SpellCard card in Deck.PlayerDeck)
            {
                GameObject Parent = Instantiate(new GameObject(), transform);
                Parent.AddComponent<Image>().sprite = card.Image;

                Cards.Add(Parent);

                GameObject Child = Instantiate(new GameObject(), Parent.transform);
                Child.AddComponent<Image>().color = new Color(1, 1, 1, .5f);

                Child.gameObject.SetActive(false); 
            }

            SelectedCard = Cards[selectedCardIndex];
        }

        private void MenuMove_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Vector2 MoveVector = obj.ReadValue<Vector2>();
            if(MoveVector.x > 0)
            {
                CycleCardsUp(); 
            } else if(MoveVector.x < 0) { CycleCardsDown();  }
            
            if(MoveVector.y > 0)
            {
                GoUpARow(); 
            } else if(MoveVector.y < 0) { GoDownARow();  }
        }

        private void Update()
        {
            SelectedCard = Cards[selectedCardIndex];
        }

        public void CycleCardsUp()
        {
            SelectedCard.transform.GetChild(0).gameObject.SetActive(false); 
            selectedCardIndex++;
            SelectedCard.transform.GetChild(0).gameObject.SetActive(true);
        }

        public void CycleCardsDown()
        {
            SelectedCard.transform.GetChild(0).gameObject.SetActive(false);
            selectedCardIndex--;
            SelectedCard.transform.GetChild(0).gameObject.SetActive(true);
        }

        public void GoDownARow()
        {
            SelectedCard.transform.GetChild(0).gameObject.SetActive(false);
            selectedCardIndex += 3;
            SelectedCard.transform.GetChild(0).gameObject.SetActive(true);
        }
        public void GoUpARow()
        {
            SelectedCard.transform.GetChild(0).gameObject.SetActive(false);
            selectedCardIndex -= 3;
            SelectedCard.transform.GetChild(0).gameObject.SetActive(true);
        }

        public void RemoveCard()
        {
            Cards.RemoveAt(selectedCardIndex);
            Destroy(SelectedCard);
            SelectedCard = Cards[selectedCardIndex];
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