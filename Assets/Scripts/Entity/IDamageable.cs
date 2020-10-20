using UnityEngine;

namespace Assets.Scripts.Entity
{
    internal interface IDamageable
    {
        void TakeDamage(float damage, Vector2? hitDirection = null);
    }
}
