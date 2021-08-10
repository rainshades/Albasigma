using System.Collections;
using UnityEngine;
using Albasigma.ARPG;
using Albasigma.UI; 

namespace Albasigma.Cards
{
    public enum CastType { nil, self, single, projectile, AOE }

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

        public void PlayCard(Transform AttackLocation)
        {
            Debug.Log("Play " + name);
            
            GameObject go; 
            if (castTye != CastType.projectile)
            {
                go = Instantiate(EffectPrefab, AttackLocation);
            }
            else
            {
                
                go = Instantiate(EffectPrefab, 
                    new Vector3(PlayerCombat.Instance.transform.position.x,
                    PlayerCombat.Instance.transform.position.y + 1.0f,
                    PlayerCombat.Instance.transform.position.z - 1.5f) 
                    ,Quaternion.identity);
                go.GetComponent<Projectile>().SetProjectile(PlayerCombat.Instance.CardLockOn.position, 0.5f, 2.0f, HitLayer);
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
