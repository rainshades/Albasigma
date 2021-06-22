using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Albasigma.ARPG; 

namespace Albasigma.UI
{
    public class PlayerStatsUI : MonoBehaviour
    {
        [SerializeField]
        PlayerCombat CombatStats; //Will be replaced with stats that can be serialized later

        public Image Health;
        public Image Drive;
        public Image Player; 

        private void Update()
        {
            Health.rectTransform.localScale = new Vector3(CombatStats.Currenthealth/CombatStats.MaxHealth, 1);
            Drive.rectTransform.localScale = new Vector3(CombatStats.CurrentDrive/CombatStats.MaxDrive, 1);
        }
    }
}