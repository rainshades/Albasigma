using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Albasigma.ARPG;


namespace Albasigma.UI
{
    public class PlayerPuaseUI : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI HealthText, DriveText, CurrencyText;
        PlayerCombat PC;
        BagObject Bag; 
        private void Awake()
        {
            PC = FindObjectOfType<PlayerCombat>();
            Bag = FindObjectOfType<BagObject>();
        }

        private void Update()
        {
            HealthText.text = PC.Currenthealth + "/" + PC.MaxHealth;
            DriveText.text = PC.CurrentDrive + "/" + PC.MaxDrive;
            CurrencyText.text = Bag.bag.currency + "" ; 
        }
    }
}