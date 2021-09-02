using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.ARPG;
using UnityEngine.UI; 


namespace Albasigma.UI
{
    /// <summary>
    /// Enemy Health bar UI
    /// </summary>
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
                    if (LastHitEnemy.MaxHealth < 600 && LastHitEnemy.Currenthealth > 0)
                    {
                        Background.rectTransform.sizeDelta = new Vector2(Background.rectTransform.sizeDelta.x, LastHitEnemy.MaxHealth + 50);
                        ForeGround.rectTransform.sizeDelta = new Vector2(ForeGround.rectTransform.sizeDelta.x, LastHitEnemy.MaxHealth + 50);
                    }

                    float healthremaining = LastHitEnemy.Currenthealth > 0 ? LastHitEnemy.Currenthealth / LastHitEnemy.MaxHealth : 0;

                    ForeGround.transform.localScale = new Vector3(1, healthremaining, 1);

                }//Sets the LastHitEnemy
                else
                {
                    Background.gameObject.SetActive(false);
                }//if no enemy hit then hide the healthbar
            }
            catch
            {
                Background.gameObject.SetActive(false);
            }
        }
    }
}