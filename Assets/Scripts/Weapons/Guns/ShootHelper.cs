using UnityEngine;

namespace Assets.Scripts.Guns
{
    public static class ShootHelper
    {
        public static void RayCastShoot(Vector2 origin, Vector2 direction, LayerMask collisionLayer, GunData gunData)
        {
            RaycastHit2D hit = Physics2D.Raycast(origin, direction, gunData.Range, collisionLayer);
            if (hit.collider)
            {
                var target = hit.collider.GetComponent<IDamageable>();
                target?.TakeDamage(gunData.Damage);
            }

            hit.rigidbody?.AddForce(-hit.normal * gunData.KnockbackForce);
        }
    }
}
