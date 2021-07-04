using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.Cards;
using Albasigma.ARPG; 

namespace Albasigma.UI
{
    public class HandUI : MonoBehaviour
    {
        public UICardObject Left, Right, Center;

        public Transform SpellSommonPossition; 
        //This will be part of the parent Player object later on

        PlayerControls inputs; 

        DeckOfCards Deck;

        int LeftCard = 0;
        int CenterCard = 1;
        int RightCard = 2; 

        private void Awake()
        {
            inputs = new PlayerControls(); 
            Deck = FindObjectOfType<DeckOfCards>();
            //Temporary Repalce with more perminent deck structure

            inputs.Hand.Shift.performed += Shift_performed;
            inputs.Hand.PlayCard.performed += PlayCard_performed;
        }

        public void Reset()
        {
            LeftCard = 0;
            CenterCard = 1;
            RightCard = 2;
        }

        private void PlayCard_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            PlayerCombat PC = FindObjectOfType<PlayerCombat>();
            if (Deck.DeckSO.spellsInHand[LeftCard].cost <= PC.CurrentDrive)
            {
                PC.CurrentDrive -= Deck.DeckSO.spellsInHand[LeftCard].cost; 
                Deck.DeckSO.spellsInHand[LeftCard].PlayCard(SpellSommonPossition);
                Deck.DeckSO.spellsInHand.RemoveAt(LeftCard);

                try
                {
                    Left.SetCard(Deck.DeckSO.spellsInHand[LeftCard]);
                }
                catch
                {
                    Left.SetCard(null);
                }
                try
                {
                    Center.SetCard(Deck.DeckSO.spellsInHand[CenterCard]);
                }
                catch
                {
                    Center.SetCard(null);
                }

                try
                {
                    Right.SetCard(Deck.DeckSO.spellsInHand[RightCard]);
                }
                catch
                {
                    Right.SetCard(null);
                }

                if (Deck.DeckSO.spellsInHand.Count == 0)
                {
                    Deck.DeckSO.DrawHand();
                }

            }
            else
            {
                Debug.Log("Need More Drive!");
            }
        }
        private void Start()
        {
            //We assume deck must be over 3 (we'll assume it is for now but this is not safe code)
            Left.SetCard(Deck.DeckSO.spellsInHand[LeftCard]);
            Center.SetCard(Deck.DeckSO.spellsInHand[CenterCard]);
            Right.SetCard(Deck.DeckSO.spellsInHand[RightCard]);
        }

        private void Shift_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if(obj.ReadValue<float>() > 0)
            {
                ShiftCardRight(); 
            }

            else if(obj.ReadValue<float>() < 0)
            {
                ShiftCardLeft();
            }
        }

        public void ShiftCardLeft()
        {
            LeftCard++;
            CenterCard++;
            RightCard++;


            try
            {
                Left.SetCard(Deck.DeckSO.spellsInHand[LeftCard]);
            }
            catch
            {
                Left.SetCard(null);
            }
            try
            {
                Center.SetCard(Deck.DeckSO.spellsInHand[CenterCard]);
            }
            catch
            {
                Center.SetCard(null);
            }

            try
            {
                Right.SetCard(Deck.DeckSO.spellsInHand[RightCard]);
            }
            catch
            {
                Right.SetCard(null);
            }

            Debug.Log("Go up");
            } //Shift the card stack up by one

        public void ShiftCardRight()
        {
            LeftCard--;
            CenterCard--;
            RightCard--;

            if (LeftCard >= 0)
                Left.SetCard(Deck.DeckSO.spellsInHand[LeftCard]);
            else
                Left.SetCard(null); 

            if (CenterCard >= 0)
                Center.SetCard(Deck.DeckSO.spellsInHand[CenterCard]);
            else
                Center.SetCard(null); 

            if (RightCard >= 0)
                Right.SetCard(Deck.DeckSO.spellsInHand[RightCard]);
            else
                Right.SetCard(null);

            Debug.Log("Go Down");
        } //Shifts the card stack down by one

        private void OnEnable()
        {
            inputs.Enable();
        }

        private void OnDisable()
        {
            inputs.Disable(); 
        }

    }
}