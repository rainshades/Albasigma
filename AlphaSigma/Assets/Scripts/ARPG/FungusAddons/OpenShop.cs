using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Albasigma.UI;
using Albasigma.Cards;

/// <summary>
/// A Fungus add on that opens the store UI 
/// </summary>

namespace Albasigma.FungusAddon
{
    [CommandInfo("Friendly", "Open Shop", "This command assigns a shop scriptable objects to the Shop content pan and opens to shop menu")]
    public class OpenShop : Command
    {
        ShopUI ShopUI;
        public GameObject CanvasScrollView; 
        public ShopSO SetShop; 
        public override void OnEnter()
        {
            base.OnEnter();
            CanvasScrollView.SetActive(true); 
            ShopUI = CanvasScrollView.GetComponentInChildren<ShopUI>();
            ShopUI.Shop = SetShop;
            ShopUI.OpenShop();
            Continue(); 
        }
    }
}