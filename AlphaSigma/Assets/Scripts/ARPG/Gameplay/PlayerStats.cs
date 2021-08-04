using UnityEngine;


namespace Albasigma.ARPG
{
    [CreateAssetMenu(fileName = "Player Stats", menuName = "Stats")]
    public class PlayerStats : ScriptableObject
    {
        public float Currenthealth, MaxHealth;
        public float CurrentDrive, MaxDrive;

        public float Attack, Speed, FlightSpeed, Mana;

        public float AttackRange;

        public PlayerLevelSystem PlayerLevel = new PlayerLevelSystem();
    }
}