using UnityEngine;
using Albasigma.ARPG; 
using System.Collections.Generic;


namespace Albasigma.Cards
{
    /// <summary>
    /// Items that show up in the shop
    /// </summary>
    [System.Serializable]
    public class ShopItem
    {
        public SpellCard card;
        public int cost;
        
        public ShopItem(int cost, SpellCard card)
        {
            this.cost = cost; this.card = card; 
        }
    }
    /// <summary>
    /// Shops that appear on the overworld that the player interacts with
    /// using Fungus/Iinteract
    /// </summary>
    [CreateAssetMenu(fileName = "New Shop", menuName = "NPCShop")]
    public class ShopSO : ScriptableObject
    {
        public List<ShopItem> Shop; 

        public void BuyCards(ShopItem C)
        {  
            Bag B = FindObjectOfType<BagObject>().bag;
           
            if(B.currency >= C.cost) { 
            B.CardsInBag.Add(C.card); 
           
            Shop.Remove(C); 
            }
        }//Adds Item to Bag

        public void SellCard(SpellCard C)
        {
            Bag B = FindObjectOfType<BagObject>().bag;

            B.currency += 100;
            B.CardsInBag.Remove(C);

            ShopItem item = new ShopItem(500, C);
        }//Removes spell/item for flat fee (temporary: Will add price to each spellCard so it has intrensic value)
    }
}
