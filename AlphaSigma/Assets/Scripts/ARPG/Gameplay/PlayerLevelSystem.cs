using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GrowthType { Attack, Magic, Drive }

namespace Albasigma.ARPG
{
    [System.Serializable]
    public class PlayerLevelSystem
    {
        public PlayerStats PlayerStatsSO; 
        public int CurrentLevel;
        public int Experience;
        public int ExperienceToLevelUp;
        public GrowthType growthType;

        public void GainExperience(int Exp)
        {
            Experience += Exp;
            try
            {
                if (Experience == ExperienceToLevelUp)
                {
                    LevelUP(); 

                }//If experience is exactly enough to give a level up it simply levels up
                else if (Experience > ExperienceToLevelUp)
                {
                    int LeftoverExperience = Experience - ExperienceToLevelUp;
                    LevelUP(); 
                    GainExperience(LeftoverExperience);

                }// LeftoverExperince is added to the next level. Called recusively if it's enough for another level on top of that
            }
            catch
            {
                Debug.Log("Max Level");
            }
        }

        int CalculateExperienceToNextLevel()
        {
            if(CurrentLevel == 1)
            {
                return 5; 
            }

            return CurrentLevel * 10 + 5;  
        }

        void LevelUP()
        {
            CurrentLevel++;
            Experience = 0;
            LevelStatsAdjustment();
            PlayerStatsSO.FullHeal();
            ExperienceToLevelUp = CalculateExperienceToNextLevel(); 
            Debug.Log("Level UP");
        }



        void LevelStatsAdjustment()
        {
            if (growthType == GrowthType.Attack)
            {
                PlayerStatsSO.Attack += 5;
                PlayerStatsSO.MaxHealth += 20;
                PlayerStatsSO.MaxDrive += 1;

                PlayerStatsSO.Mana++;
            } else if(growthType == GrowthType.Drive)
            {
                PlayerStatsSO.Attack += 1;
                PlayerStatsSO.MaxHealth += 15;
                PlayerStatsSO.MaxDrive += 5;

                PlayerStatsSO.Mana++;
            } else if(growthType == GrowthType.Magic)
            {
                PlayerStatsSO.Attack += 1;
                PlayerStatsSO.MaxHealth += 15;
                PlayerStatsSO.MaxDrive += 1;

                PlayerStatsSO.Mana += 2;
            }
        }
    }


}