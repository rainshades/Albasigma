using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    [System.Serializable]
    public class PlayerLevelSystem
    {
        public PlayerStats PlayerStatsSO; 
        public int CurrentLevel;
        public int Experience;
        public List<int> ExperienceToLevelUp; 

        public void GainExperience(int Exp)
        {
            Experience += Exp;
            try
            {
                if (Experience == ExperienceToLevelUp[CurrentLevel])
                {
                    LevelUP(); 

                }//If experience is exactly enough to give a level up it simply levels up
                else if (Experience > ExperienceToLevelUp[CurrentLevel])
                {
                    int LeftoverExperience = Experience - ExperienceToLevelUp[CurrentLevel];
                    LevelUP(); 
                    GainExperience(LeftoverExperience);

                }// LeftoverExperince is added to the next level. Called recusively if it's enough for another level on top of that
            }
            catch
            {
                Debug.Log("Max Level");
            }
        }

        void LevelUP()
        {
            CurrentLevel++;
            Experience = 0;
            LevelStatsAdjustment();

            Debug.Log("Level UP");
        }

        void LevelStatsAdjustment()
        {
            PlayerStatsSO.Attack += 1;
            PlayerStatsSO.MaxHealth += 15;
            PlayerStatsSO.MaxDrive += 5;
            
            PlayerStatsSO.CurrentDrive = PlayerStatsSO.MaxDrive;
            PlayerStatsSO.Currenthealth = PlayerStatsSO.MaxHealth;

            PlayerStatsSO.Mana++;
        }
    }


}