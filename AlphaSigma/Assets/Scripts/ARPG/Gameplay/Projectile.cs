using UnityEngine;

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

        public void SetProjectile(Vector3 LauchDestination, float hitRadius, float damage, LayerMask HitLayer)
        {
            LaunchDestination = LauchDestination; HitRadius = hitRadius; this.damage = damage; this.HitLayer = HitLayer;
            IgnoreLayer = transform.gameObject.layer;

            transform.parent = null;
        } // MonoBehaviours can't have constructors so this is the best of a bad situation 

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, HitRadius); 
        }

        private void FixedUpdate()
        {
            transform.LookAt(LaunchDestination + Vector3.up);//Orients the projectiles towards it's destination 

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
                    }//Player takes damage if they aren't blocking and then the object is destroyed

                    if(collider.gameObject.tag == "Untagged")
                    {
                        Destroy(gameObject);
                    }//Destroy when it hits anything else
                }
            }
        }
    }
}