using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albasigma.ARPG
{
    public interface IAreaOfEffectSpell
    {
        public void inSpellArea(int Damage);
    }

    public class BaseAoeAbility  : MonoBehaviour, IAreaOfEffectSpell
    {
        public float AreaOfEffect;
        public float Damage; 
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
        }

        private void Awake()
        {
            transform.localScale = new Vector3(AreaOfEffect, AreaOfEffect, AreaOfEffect);     
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, AreaOfEffect); 
        }

        private void Update()
        {
            if(currentDamageTick == 0)
            {
                currentDamageTick = DamageTick;
                inSpellArea(5); 
            }
            else
            {
                DamageTick -= Time.deltaTime; 
            }
        }


    }
}