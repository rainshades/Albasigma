using System.Collections.Generic;
using UnityEngine;


namespace Albasigma.ARPG
{
    [System.Serializable]
    public class Skill
    {
        public string name;
        public bool unlocked;
        public int ManaCost;
        public GameObject Effect;
    }//Skills cost mana to unlcok 

    /// <summary>
    /// Skill list
    /// For the Player but there might be others later
    /// </summary>
    [CreateAssetMenu(fileName ="New Skill List", menuName ="Skill List")]
    public class SkillList : ScriptableObject, IReset
    {
        public List<Skill> Skills = new List<Skill>();

        public void Reset()
        {
            foreach(Skill skill in Skills)
            {
                skill.unlocked = false; 
            }
        }
    }


    public interface IReset
    {
        public void Reset();
    }
}