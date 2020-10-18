using UnityEngine;

namespace Assets.Scripts
{
    internal interface IDamageable
    {
        void TakeDamage(float damage, Vector2? hitDirection = null);
    }
}
