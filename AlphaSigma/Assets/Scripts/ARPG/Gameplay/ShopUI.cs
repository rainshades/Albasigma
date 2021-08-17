using Albasigma.ARPG;
using Albasigma.Cards;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem; 

namespace Albasigma.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class ShopUI : MonoBehaviour
    {
        Bag PlayerBag;
        public ShopSO Shop;
        [SerializeField]
        TextMeshProUGUI CurrencyText; 

        PlayerControls pc;

        int index = 0;

        bool ShopOpen = false;
        bool BagOpen = false;

        GameObject SelectedItem;
        //for controller players to be able to cycle through the list there must be an item for them to select 

        private void Awake()
        {
            pc = new PlayerControls(); 
            PlayerBag = FindObjectOfType<BagObject>().bag;

            pc.UI.MenuMove.performed += MenuMove_performed;
            pc.UI.SwitchMenu.performed += SwitchMenu_performed;
        }

        private void SwitchMenu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (ShopOpen)
            {
                OpenBag();
            } else if (BagOpen)
            {
                OpenShop(); 
            }
        }

        private void MenuMove_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Vector2 indexmover = obj.ReadValue<Vector2>();
            try
            {
                SelectedItem.transform.GetChild(0).gameObject.SetActive(false);
            }
            catch
            {
                Debug.Log("empty");
            }
            if ((indexmover.x > 0 || indexmover.y > 0 ) && index > 0)
            {
                index--; 
            } else if((indexmover.y < 0 || indexmover.y < 0) && index < transform.childCount - 1)
            {
                index++; 
            }// cycling through the shop
        }

        private void LateUpdate()
        {
            CurrencyText.text = PlayerBag.currency.ToString();
            try
            {
                SelectedItem = transform.GetChild(index).gameObject;
                SelectedItem.transform.GetChild(0).gameObject.SetActive(true);
            } catch{
                Debug.LogWarning("index out of range");
            }//Checks to see if the index has changed every frame and that it is in the range of items in the shop
            //avoiding errors as to not crash the store as a a whole. 

            if (Gamepad.current.buttonSouth.wasReleasedThisFrame)
            {
                if (ShopOpen)
                {
                    Buy(index); 
                }

                if (BagOpen)
                {
                    Sell(index); 
                }
            }//button south is often the confirm button so button south was chosen as the buy/sell button
        }

        public void OpenShop()
        {
            EmptyUI();
            ShopOpen = true;
            BagOpen = false; 
            foreach(ShopItem item in Shop.Shop)
            {                
                GameObject Parent = new GameObject();
                Parent.transform.parent = transform;
                Parent.AddComponent<Image>().sprite = item.card.Image;
                Parent.AddComponent<CardInfoHolder>().Card = item.card;
                //Card's parent object   

                GameObject Child_0 = new GameObject();
                Child_0.transform.parent = Parent.transform;
                Child_0.transform.localPosition = Vector3.zero;
                Child_0.AddComponent<Image>().color = new Color(1, 1, 1, .5f);
                Child_0.gameObject.SetActive(false);
                //Card Color Background and image

                GameObject Child_1 = new GameObject();
                Child_1.transform.parent = Parent.transform;
                Child_1.transform.localPosition = Vector3.zero;
                Child_1.AddComponent<TextMeshProUGUI>().text = "D" + item.cost;

                Child_1.GetComponent<RectTransform>().localPosition = new Vector3(106, 0, 0);
                Child_1.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 50);
                //Card's price text
            }
        }

        public void OpenBag()
        {
            EmptyUI();
            BagOpen = true;
            ShopOpen = false; 
            foreach(SpellCard Card in PlayerBag.CardsInBag)
            {
                GameObject Parent = new GameObject();
                Parent.transform.parent = transform;
                Parent.AddComponent<Image>().sprite = Card.Image;
                Parent.AddComponent<CardInfoHolder>().Card = Card;
                //Card base object

                GameObject Child = new GameObject();
                Child.transform.parent = Parent.transform;
                Child.transform.localPosition = Vector3.zero;
                Child.AddComponent<Image>().color = new Color(1, 1, 1, .5f);
                Child.gameObject.SetActive(false);
                //CardImage and Color
            }
        }

        void EmptyUI()
        {
            index = 0; 
            for(int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        } // Empty's the children so the next shop does not carry over data

        public void Buy(int ShopIndex)
        {
            if (Shop.Shop[ShopIndex].cost <= PlayerBag.currency)
            {
                PlayerBag.CardsInBag.Add(Shop.Shop[ShopIndex].card);
                PlayerBag.currency -= Shop.Shop[ShopIndex].cost;
                Shop.Shop.RemoveAt(ShopIndex);
                Destroy(transform.GetChild(ShopIndex).gameObject);
            }
        }// Player buys object and palces it in back

        public void Sell(int BagIndex)
        {
            PlayerBag.CardsInBag.RemoveAt(BagIndex);
            PlayerBag.currency += 500;
            Destroy(transform.GetChild(BagIndex).gameObject);
        } // Place sells object, sold objects cannot be bought back

        private void OnEnable()
        {
            FindObjectOfType<PlayerCombat>().Controls.Disable();
            FindObjectOfType<PlayerMovement>().inputs.Disable();
            FindObjectOfType<HandUI>().inputs.Disable(); 
            pc.Enable();
        }

        private void OnDisable()
        {
            EmptyUI();
            FindObjectOfType<PlayerCombat>().Controls.Enable();
            FindObjectOfType<PlayerMovement>().inputs.Enable();
            FindObjectOfType<HandUI>().inputs.Enable();

            pc.Disable(); 
        }
    }
}