using System.Collections.Generic;
using UnityEngine;


namespace Albasigma.ARPG
{
    /// <summary>
    /// Skill list
    /// For the Player but there might be others later
    /// </summary>
    [CreateAssetMenu(fileName ="New Skill List", menuName ="Skill List")]
    public class SkillList : ScriptableObject
    {
        [System.Serializable]
        public struct Skill
        {
            public string name;
            public bool unlocked;
            public int ManaCost;
            public GameObject Effect; 
        }//Skills cost mana to unlcok 

        public List<Skill> Skills = new List<Skill>(); 
    }
}