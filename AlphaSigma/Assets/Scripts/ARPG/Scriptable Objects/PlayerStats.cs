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
        public float Currenthealth, MaxHealth;//Constant Scaling
        public float CurrentDrive, MaxDrive;//Constant Scaling

        public float Attack, Speed, FlightSpeed, Mana, currentMana;//Slower Scaling

        public float AttackRange;//Not Adjustable 

        public PlayerLevelSystem PlayerLevel = new PlayerLevelSystem();
    }
}