using UnityEngine;

namespace Albasigma.ARPG
{
    public class Projectile : MonoBehaviour
    {
        public Vector3 LaunchDestination;
        public LayerMask HitLayer, IgnoreLayer;
        public float HitRadius;
        public float damage;

        public void SetProjectile(Vector3 LauchDestination, float hitRadius, float damage, LayerMask HitLayer)
        {
            LaunchDestination = LauchDestination; HitRadius = hitRadius; this.damage = damage; this.HitLayer = HitLayer;
            IgnoreLayer = transform.gameObject.layer;

            transform.parent = null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, HitRadius); 
        }

        private void FixedUpdate()
        {
            transform.LookAt(LaunchDestination + Vector3.up);

            transform.Translate(Vector3.forward * Time.deltaTime);
            
            Collider[] col = Physics.OverlapSphere(transform.position, HitRadius);

            if (col.Length > 0)
            {
                foreach(Collider collider in col)
                {
                    if (collider.gameObject.tag == "Player")
                    {
                        collider.GetComponent<ICombatEntity>().TakeDamage(damage);
                        Destroy(gameObject);
                    }

                    if(collider.gameObject.tag == "Untagged")
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }



    }
}