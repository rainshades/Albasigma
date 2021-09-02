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
        [SerializeField]
        Deck Deck;
        [SerializeField]
        BagObject PlayerBag;

        public Transform CardsInBagPanel; 

        [SerializeField]
        GameObject SelectedCard;

        [SerializeField]
        Transform SelectedUI; 

        [SerializeField]
        List<GameObject> CardsInDeck = new List<GameObject>();

        [SerializeField]
        List<GameObject> CardsInBag = new List<GameObject>(); 

        int index = 0;

        bool inBag, inDeck; 

        PlayerControls pc;

        private void Awake()
        {
            pc = new PlayerControls();

            pc.UI.MenuMove.performed += MenuMove_performed;
            pc.UI.MoveToBag.performed += MoveToBag_performed;
            pc.UI.MoveToDeck.performed += MoveToDeck_performed;
            pc.UI.SwitchMenu.performed += SwitchMenu_performed;

            PlayerBag = FindObjectOfType<BagObject>(); 


            CreateCardImages(Deck.PlayerDeck, transform, true);
            CreateCardImages(PlayerBag.bag.CardsInBag, CardsInBagPanel, false);

            SelectedCard = CardsInDeck[index];
            SelectedCard.transform.GetChild(0).gameObject.SetActive(true);

            SelectedUI = transform;

            inDeck = true;
            inBag = false; 
        }

        private void SwitchMenu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            MenuSwap(); 
        }

        void MenuSwap()
        {
            SelectedCard.transform.GetChild(0).gameObject.SetActive(false);
            index = 0;

            if (inDeck)
            {
                SelectedUI = CardsInBagPanel;
                SelectedCard = CardsInBag[index];
            } // Switching from the deck

            if (inBag)
            {
                SelectedUI = transform;
                SelectedCard = CardsInDeck[index];
            }// Switching from the bag

            inDeck = !inDeck;
            inBag = !inBag;
            SelectedCard.transform.GetChild(0).gameObject.SetActive(true);
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
                Parent.AddComponent<CardInfoHolder>().Card = card; 

                if(isInDeck)
                    CardsInDeck.Add(Parent);

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
            SelectedCard.transform.GetChild(0).gameObject.SetActive(false);

            if (MoveVector.x > 0)
            {

                CycleCardsUp();

            }
            else if(MoveVector.x < 0) {
                CycleCardsDown();
            }
            
            if(MoveVector.y > 0)
            {
                GoUpARow(); 
            } else if(MoveVector.y < 0) {
                GoDownARow(); 
            }

            if (inDeck)
            {
                SelectedCard = CardsInDeck[index];
            }

            if (inBag)
            {
                SelectedCard = CardsInBag[index];
            }

            SelectedCard.transform.GetChild(0).gameObject.SetActive(true);

        }

        public void CycleCardsUp()
        {
            if(index < SelectedUI.childCount - 1)
            index++; 
        }

        public void CycleCardsDown()
        {
            if(index > 0)
            index--; 
        }

        public void GoDownARow()
        {
            if(index + 3 < SelectedUI.childCount -1)
            index += 3; 
        }
        public void GoUpARow()
        {
            if (index - 3 > 0)
                index -= 3;
            else
                index = 0; 
        }

        public void MoveCard(Transform newParent)
        {
            SelectedCard.transform.SetParent(newParent);
            if (inDeck)
            {
                CardsInBag.Add(SelectedCard);
                CardsInDeck.RemoveAt(index);
            }
            if (inBag)
            {
                CardsInDeck.Add(SelectedCard);
                CardsInBag.RemoveAt(index);
            }
            MenuSwap(); 
        }

        public void SaveDeck() //Temp
        {
            Deck.PlayerDeck.Clear(); 
            for(int i = 0; i < transform.childCount; i++)
            {
                Deck.PlayerDeck.Add(transform.GetChild(i).GetComponent<CardInfoHolder>().Card);
            } // Removes cards from the deck and fills it with the children of the UI
            //There is likely a faster more efficient way to edit the deck in real time than this
        }

        private void OnEnable()
        {
            FindObjectOfType<PlayerCombat>().Controls.Disable();
            FindObjectOfType<PlayerMovement>().inputs.Disable();
            FindObjectOfType<HandUI>().inputs.Disable(); 
            pc.Enable(); 
        }

        private void OnDisable()
        {
            SaveDeck(); 
            FindObjectOfType<PlayerCombat>().Controls.Enable();
            FindObjectOfType<PlayerMovement>().inputs.Enable();
            FindObjectOfType<HandUI>().inputs.Enable();
            pc.Disable(); 
        }
    }
}