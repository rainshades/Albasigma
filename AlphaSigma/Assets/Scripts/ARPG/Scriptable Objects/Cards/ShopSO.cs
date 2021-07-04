using UnityEngine;
using Albasigma.ARPG; 
using System.Collections.Generic;


namespace Albasigma.Cards
{
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
        }
        public void SellCard(SpellCard C)
        {
            Bag B = FindObjectOfType<BagObject>().bag;

            B.currency += 100;
            B.CardsInBag.Remove(C);

            ShopItem item = new ShopItem(500, C);
        }
    }
}
