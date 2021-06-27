using UnityEngine; 

namespace Albasigma.ARPG
{
    public interface ICombatEntity
    {
        public void Attack(float damage, GameObject entity);
        public void TakeDamage(float damage);
        public void OnDeath();
    }
}