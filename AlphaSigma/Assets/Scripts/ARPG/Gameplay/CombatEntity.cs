using UnityEngine; 

namespace Albasigma.ARPG
{
    public interface CombatEntity
    {
        public void Attack(int damage, GameObject entity);
        public void TakeDamage(int damage);
    }
}