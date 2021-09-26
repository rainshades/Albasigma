using System.Collections;
using UnityEngine;
using Albasigma.ARPG;
using Albasigma.UI; 

namespace Albasigma.Cards
{
    public enum CastType { nil, self, single, projectile, singleUse, AOE }

    /// <summary>
    /// How spells/battle items are condecuted in the game so they aren't completely reliable/op
    /// </summary>
    [CreateAssetMenu(fileName = "New Spell", menuName = "Spell Card")]
    public class SpellCard : ScriptableObject
    {
        public float spelltime; //The amount of time the spell is active

        //Desc, Sprite, damage/effects
        public Sprite Image;
        public int cost;
        public CastType castTye;

        public GameObject EffectPrefab;
        public LayerMask HitLayer;
        public LayerMask IgnoreLayer; 

        public virtual void PlayCard(Transform AttackLocation)
        {
            Debug.Log("Play " + name);
            
            GameObject go; 
            if (castTye != CastType.projectile)
            {
                go = Instantiate(EffectPrefab, AttackLocation);
                go.transform.parent = null; 
            }
            else
            {
                
                go = Instantiate(EffectPrefab, 
                    PlayerCombat.Instance.ProjectileSpawnPoint.position
                    ,Quaternion.identity);
                go.GetComponent<Projectile>().SetProjectile(PlayerCombat.Instance.CardLockOn.position, HitLayer, IgnoreLayer, spelltime);
            }


            if (castTye == CastType.self)
                go.GetComponent<ISelfEffect>().OnSelfActivation();

            go.GetComponent<MonoBehaviour>().StartCoroutine(RemoveSpellCastTime(go));
        }//Summons the card object the card at a the Card Effect transform location 

        public IEnumerator RemoveSpellCastTime(GameObject prefab)
        {
            yield return new WaitForSecondsRealtime(spelltime);
            Destroy(prefab); 
        }//Destroys the spell in question when it is no longer active
    }
}
