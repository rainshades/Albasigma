using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.ARPG; 

namespace Albasigma.Cards
{
    public class IceOneSpell : MonoBehaviour, ISelfEffect
    {
        bool IceOneBuffActive
        {
            get
            {
                return FindObjectOfType<IceOneSpell>(); 
            }
        }

        [SerializeField]
        PlayerStats PlayerStats;
        float BaseAttack; 

        public void OnSelfActivation()
        {
            if (IceOneBuffActive)
            {
                Debug.Log("Ice Buff Active");
            }
            else
            {
                BaseAttack = PlayerStats.Attack;
                PlayerStats.Attack *= -1.15f; 
            }
        }


        private void OnDestroy()
        {
            PlayerStats.Attack = BaseAttack; 
        }
    }
}