using UnityEngine; 

namespace Albasigma.ARPG
{
    /// <summary>
    /// Interface for entities that
    /// Attack
    /// Take Damage
    /// And can die
    /// </summary>
    public interface ICombatEntity
    {
        public void Attack(float damage, GameObject entity);
        public void TakeDamage(float damage);
        public void OnDeath();
    }
}