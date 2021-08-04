using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.ARPG;
using UnityEngine.UI; 


namespace Albasigma.UI
{
    public class HealthBar : MonoBehaviour
    {
        public DummyCombat LastHitEnemy;

        public static HealthBar instance;

        [SerializeField]
        Image Background, ForeGround; 

        private void Awake()
        { 
            instance = this; 
        }

        private void Update()
        {
            try
            {
                if (LastHitEnemy != null)
                {
                    Background.gameObject.SetActive(true);
                    if(LastHitEnemy.MaxHealth < 600)
                    {
                        Background.rectTransform.sizeDelta = new Vector2(Background.rectTransform.sizeDelta.x, LastHitEnemy.MaxHealth + 50);
                        ForeGround.rectTransform.sizeDelta = new Vector2(ForeGround.rectTransform.sizeDelta.x, LastHitEnemy.MaxHealth + 50);
                    }
                    ForeGround.transform.localScale = new Vector3(1, LastHitEnemy.Currenthealth / LastHitEnemy.MaxHealth, 1);
                }
                else
                {
                    Background.gameObject.SetActive(false);
                }
            }
            catch
            {
                Background.gameObject.SetActive(false);
            }
        }
    }
}