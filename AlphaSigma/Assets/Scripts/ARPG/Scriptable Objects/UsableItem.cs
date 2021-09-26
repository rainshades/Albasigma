using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.ARPG; 

namespace Albasigma.Cards
{
    public class UsableItem : SpellCard
    {
        public enum UseableType {Potion, Protein, Mint}
        [SerializeField]
        UseableType ItemType;
        [SerializeField]
        float AmountOffBuff;
        [SerializeField]
        int AmountOfItemLeft;
        [SerializeField]
        PlayerStats PlayerStats;

        private void Awake()
        {
            castTye = CastType.singleUse; 
        }

        public override void PlayCard(Transform AttackLocation)
        {            
            if(AmountOfItemLeft > 0)
            {
                if(ItemType == UseableType.Potion)
                {
                    if(PlayerStats.Currenthealth + AmountOffBuff >= PlayerStats.MaxHealth)
                    {
                        PlayerStats.FullHeal();
                    }
                    else
                    {
                        PlayerStats.Currenthealth += AmountOffBuff;
                    }
                } else if(ItemType == UseableType.Protein)
                {
                    ProteinBuff(AmountOffBuff);
                } else if(ItemType == UseableType.Mint)
                {
                    if (PlayerStats.CurrentDrive + AmountOffBuff >= PlayerStats.MaxDrive)
                    {
                        PlayerStats.FullHeal();
                    }
                    else
                    {
                        PlayerStats.CurrentDrive += AmountOffBuff;
                    }
                }
            }

            AmountOfItemLeft--; 
        }

        IEnumerable ProteinBuff(float BuffAmount)
        {
            float Attack = PlayerStats.Attack;
            PlayerStats.Attack *= BuffAmount;
            yield return new WaitForSecondsRealtime(15.0f);
            PlayerStats.Attack = Attack; 
        }
    }
}