using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.UI; 

namespace Albasigma.ARPG
{
    public class GroundHitEffect : MonoBehaviour
    {
        int TicksActive = 5;
        float CurrentTick = 0;
        int Damage = 1;

        private void Update()
        {
            Collider[] col = Physics.OverlapSphere(transform.position, transform.parent.localScale.x);
            foreach (Collider cols in col)
            {
                if (cols.tag == "Enemy")
                {
                   // cols.GetComponent<DummyCombat>().TakeDamage(Damage);
                    Vector3 KnockbackDirection = (cols.transform.position - transform.position) * -1;
                    cols.GetComponent<DummyMovement>().KnockbackCalc(cols.GetComponent<DummyMovement>(),
                        KnockbackDirection);
                    HealthBar.instance.LastHitEnemy = cols.GetComponent<DummyCombat>();
                    Debug.Log("Hit by ground slam");
                }
            }

            if (CurrentTick < TicksActive)
            {
                CurrentTick += Time.deltaTime;
                transform.parent.localScale = new Vector3(transform.parent.localScale.x + Time.deltaTime * TicksActive, 0.5f,
                    transform.parent.localScale.z + Time.deltaTime * TicksActive);
            }
            else
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}