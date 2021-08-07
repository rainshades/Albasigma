using UnityEngine;


namespace Albasigma.ARPG
{
    /// <summary>
    /// Player stats Scriptable object 
    /// Holds a serialized version of player's information 
    /// </summary>
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