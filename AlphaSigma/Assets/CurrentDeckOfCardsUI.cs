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
        Bag PlayerBag;

        public Transform CardsInBagPanel; 

        [SerializeField]
        GameObject SelectedCard;

        [SerializeField]
        Transform SelectedUI; 

        [SerializeField]
        List<GameObject> Cards = new List<GameObject>();

        int deckSelectedCardIndex = 0;
        int bagSelectedCardIndex = 0; 

        PlayerControls pc;

        private void Awake()
        {
            pc = new PlayerControls();

            pc.UI.MenuMove.performed += MenuMove_performed;
            pc.UI.MoveToBag.performed += MoveToBag_performed;
            pc.UI.MoveToDeck.performed += MoveToDeck_performed;
            pc.UI.SwitchMenu.performed += SwitchMenu_performed;

            Deck = FindObjectOfType<DeckOfCards>();
            PlayerBag = FindObjectOfType<Bag>(); 


            CreateCardImages(Deck.PlayerDeck, transform, true);
            CreateCardImages(PlayerBag.CardsInBag, CardsInBagPanel, false);

            SelectedCard = Cards[deckSelectedCardIndex];

            SelectedUI = transform; 
        }

        private void SwitchMenu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (SelectedUI == transform)
            {
                SelectedUI = CardsInBagPanel;
                SelectedCard = Cards[bagSelectedCardIndex];
            }
            else
            {
                SelectedUI = transform;
                SelectedCard = Cards[deckSelectedCardIndex];
            }
        }

        private void MoveToDeck_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            MoveCard(transform); 
        }

        private void MoveToBag_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            MoveCard(CardsInBagPanel);
        }

        public void CreateCardImages(List<SpellCard> Cardset, Transform GrandParent, bool isInDeck)
        {
            foreach (SpellCard card in Cardset)
            {
                GameObject Parent = new GameObject();
                Parent.transform.parent = GrandParent;
                Parent.AddComponent<Image>().sprite = card.Image;

                if(isInDeck)
                    Cards.Add(Parent);

                GameObject Child = new GameObject();
                Child.transform.parent = Parent.transform;
                Child.transform.localPosition = Vector3.zero; 
                Child.AddComponent<Image>().color = new Color(1, 1, 1, .5f);

                Child.gameObject.SetActive(false);
            }

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
            if (SelectedUI == transform)
                SelectedCard = Cards[deckSelectedCardIndex];
            else
                SelectedCard = Cards[bagSelectedCardIndex];
        }

        public void CycleCardsUp()
        {
            SelectedCard.transform.GetChild(0).gameObject.SetActive(false);

            if (SelectedUI == transform)
                deckSelectedCardIndex++;
            else
                bagSelectedCardIndex++;

            SelectedCard.transform.GetChild(0).gameObject.SetActive(true);
        }

        public void CycleCardsDown()
        {
            SelectedCard.transform.GetChild(0).gameObject.SetActive(false);

            if(SelectedUI == transform)
            {
                deckSelectedCardIndex--;
            }
            else
            {
                bagSelectedCardIndex--;
            }

            SelectedCard.transform.GetChild(0).gameObject.SetActive(true);
        }

        public void GoDownARow()
        {
            SelectedCard.transform.GetChild(0).gameObject.SetActive(false);
            if(SelectedUI == transform)
            {
                deckSelectedCardIndex += 3;
            }
            else
            {
                bagSelectedCardIndex += 3;
            }
            SelectedCard.transform.GetChild(0).gameObject.SetActive(true);
        }
        public void GoUpARow()
        {
            SelectedCard.transform.GetChild(0).gameObject.SetActive(false);

            if(SelectedUI == transform)
            {
                deckSelectedCardIndex -= 3;
            }
            else
            {
                bagSelectedCardIndex -= 3;
            }

            SelectedCard.transform.GetChild(0).gameObject.SetActive(true);
        }

        public void MoveCard(Transform newParent)
        {
            SelectedCard.transform.SetParent(newParent); 

            /*
            Cards.RemoveAt(deckSelectedCardIndex);
            Destroy(SelectedCard);
            SelectedCard = Cards[deckSelectedCardIndex]; */
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