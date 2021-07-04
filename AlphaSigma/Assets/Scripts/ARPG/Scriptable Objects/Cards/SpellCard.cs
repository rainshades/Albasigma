using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.ARPG;

namespace Albasigma.Cards
{
    public enum CastType { nil, self, single, AOE }

    [CreateAssetMenu(fileName = "New Spell", menuName = "Spell Card")]
    public class SpellCard : ScriptableObject
    {
        [SerializeField]
        float spelltime; 

        //Desc, Sprite, damage/effects
        public Sprite Image;
        public int cost;
        public CastType castTye;

        [SerializeField]
        GameObject EffectPrefab; 

        public void PlayCard(Transform AttackLocation)
        {
            Debug.Log("Play " + name);
            GameObject go = Instantiate(EffectPrefab, AttackLocation);
            go.transform.parent = null;
            if(castTye == CastType.self)
                go.GetComponent<ISelfEffect>().OnSelfActivation();
            go.GetComponent<MonoBehaviour>().StartCoroutine(RemoveSpellCastTime(go));
        }

        public IEnumerator RemoveSpellCastTime(GameObject prefab)
        {
            yield return new WaitForSecondsRealtime(spelltime);
            Destroy(prefab); 
        }
    }
}