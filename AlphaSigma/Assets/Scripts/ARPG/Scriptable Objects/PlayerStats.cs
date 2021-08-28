using UnityEngine;

namespace Albasigma.ARPG
{
    /// <summary>
    /// Player stats Scriptable object 
    /// Holds a serialized version of player's information 
    /// </summary>
    [CreateAssetMenu(fileName = "Player Stats", menuName = "Stats")]
    public class PlayerStats : ScriptableObject, IReset
    {
        public float Currenthealth, MaxHealth;//Constant Scaling
        public float CurrentDrive, MaxDrive;//Constant Scaling

        public float Attack, Speed, FlightSpeed, Mana, currentMana;//Slower Scaling

        public float AttackRange;//Not Adjustable 

        public PlayerLevelSystem PlayerLevel = new PlayerLevelSystem();
        public BaseStats Base; 

        private void OnValidate()
        {
            if (PlayerLevel.CurrentLevel == 1)
            {
                SetToBase(); 
            }//When Level is 1 we make sure we have base stats 
            //We only set level to one in the inspector 
        }

        public void SetToBase()
        {
            MaxHealth = Base.BaseHealth; MaxDrive = Base.BaseDrive; Attack = Base.BaseAttack;
            Speed = Base.BaseSpeed; Mana = Base.BaseMana;

            Currenthealth = MaxHealth; CurrentDrive = MaxDrive; 
        }

        public void FullHeal()
        {
            CurrentDrive = MaxDrive; Currenthealth = MaxHealth; 
        }

        public void Reset()
        {
            PlayerLevel.CurrentLevel = 1; 
        }

        [System.Serializable]
        public struct BaseStats
        {
            public float BaseHealth, BaseDrive, BaseAttack, BaseSpeed, BaseMana;
        }
    }
}