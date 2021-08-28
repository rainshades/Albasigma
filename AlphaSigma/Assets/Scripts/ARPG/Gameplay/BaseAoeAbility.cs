using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albasigma.ARPG
{
    public interface IAreaOfEffectSpell
    {
        public void inSpellArea(int Damage);
        //What happens when something is in the spell AOE
        //Can be used for damage, but can also be used to apply abilities/status conditions in the AOE as well using int to signify the condition type
    }

    public class BaseAoeAbility  : MonoBehaviour, IAreaOfEffectSpell
    {
        public float AreaOfEffect;
        public int Damage; 
        public float DamageTick;
        [SerializeField]
        private float currentDamageTick = 0;

        [SerializeField]
        LayerMask DamageLayer; 

        public void inSpellArea(int damage)
        {
            try
            {
                Collider[] col = Physics.OverlapSphere(transform.position, AreaOfEffect, DamageLayer);
                foreach(Collider collider in col)
                {
                    collider.gameObject.GetComponent<ICombatEntity>().TakeDamage(damage); 
                }
            }
            catch
            {
                //nothing in collider
            }
        }//At base. Anything in the collider takes damage 

        private void Awake()
        {
            transform.localScale = new Vector3(AreaOfEffect, AreaOfEffect, AreaOfEffect);  
            //This base AOE is a sphere.
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, AreaOfEffect); 
        }

        private void Update()
        {
            if(currentDamageTick <= 0)
            {
                currentDamageTick = DamageTick;
                inSpellArea(Damage); 
            } // Spell damage happens over tick
            else
            {
                currentDamageTick -= Time.deltaTime; 
            }// Decreases tick based on framerate
            //This may be better handled with a coroutine
        }


    }
}