using Albasigma.ARPG;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Albasigma.UI
{
    /// <summary>
    /// UI for the cards currently in the hand
    /// Player needs to be able to choose the card they want to Play by rotating the hand up and down
    /// Max 5 cards in hand
    /// Can trash the hand and draw 5 new cards
    /// </summary>
    public class HandUI : MonoBehaviour
    {
        public UICardObject Left, Right, Center;

        public Transform SpellSummonPosition; 
        //This will be part of the parent Player object later on

        public PlayerControls inputs; 

        DeckOfCards Deck;

        PlayerAnimationController PAC; 

        int LeftCard = 0;
        int CenterCard = 1;
        int RightCard = 2;

        public static HandUI instance; 

        private void Awake()
        {
            inputs = new PlayerControls();
            PAC = FindObjectOfType<PlayerAnimationController>(); 
            Deck = FindObjectOfType<DeckOfCards>();
            //Temporary Repalce with more perminent deck structure
            instance = this; 

            inputs.Hand.Shift.performed += Shift_performed;
            inputs.Hand.PlayCard.performed += PlayCard_performed;
        }

        private void Update()
        {
            if (Gamepad.all.Count == 0)
            {
                Vector2 MouseWheel = Mouse.current.scroll.ReadValue();
                float scroll = MouseWheel.y;
                if (scroll > 0)
                {
                    ShiftCardRight();
                }
                else if (scroll < 0)
                {
                    ShiftCardLeft();
                }
            }
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
                Deck.DeckSO.spellsInHand[LeftCard].PlayCard(SpellSummonPosition);
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

                PAC.CastSpell(); 

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
            if (Deck.DeckSO.PlayerDeck.Count > 3)
            {
                Left.SetCard(Deck.DeckSO.spellsInHand[LeftCard]);
                Center.SetCard(Deck.DeckSO.spellsInHand[CenterCard]);
                Right.SetCard(Deck.DeckSO.spellsInHand[RightCard]);
            }
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


        /// <summary>
        /// Why did I do this two different ways???
        /// Standardize this...
        /// </summary>
       
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