using UnityEngine;
using System.Collections; 

namespace Albasigma.ARPG
{
    /// <summary>
    /// Practice Projectile
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        public Vector3 LaunchDestination;
        public LayerMask HitLayer, IgnoreLayer;
        public float HitRadius;
        public float damage;
        public float speed;

        public void SetProjectile(Vector3 LauchDestination, LayerMask HitLayer, float DestroyTimer)
        {
            LaunchDestination = LauchDestination; this.HitLayer = HitLayer;
            StartCoroutine(DestuctionTimer(DestroyTimer));
            IgnoreLayer = transform.gameObject.layer;

            transform.parent = null;
        } // MonoBehaviours can't have constructors so this is the best of a bad situation 

        public void SetProjectile(Vector3 LauchDestination, LayerMask HitLayer, LayerMask IgnoreLayer, float DestroyTimer)
        {
            LaunchDestination = LauchDestination; this.HitLayer = HitLayer;
            StartCoroutine(DestuctionTimer(DestroyTimer));
            this.IgnoreLayer = IgnoreLayer;

            transform.parent = null;
        } // MonoBehaviours can't have constructors so this is the best of a bad situation 
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, HitRadius); 
        }
        
        IEnumerator DestuctionTimer(float time)
        {
            yield return new WaitForSecondsRealtime(time);
            Destroy(gameObject); 
        }

        private void FixedUpdate()
        {
            transform.LookAt(LaunchDestination + Vector3.up);//Orients the projectiles towards it's destination 

            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            
            Collider[] col = Physics.OverlapSphere(transform.position, HitRadius, HitLayer);

            if (col.Length > 0)
            {
                try
                {
                    col[0].GetComponent<ICombatEntity>().TakeDamage(damage);
                }
                catch
                {
                    col[0].GetComponentInParent<ICombatEntity>().TakeDamage(damage); 
                }
                Destroy(gameObject); 
            }
        }
    }
}