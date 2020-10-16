using UnityEngine;

namespace Assets.Scripts.Weapons.Guns
{
    public class RaycastGun : Gun
    {
        public override void SecondaryAction() { }

        public override void Shoot()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, gunData.Range, collisionLayer);
            if (hit.collider)
            {
                var target = hit.collider.GetComponent<IDamageable>();
                target?.TakeDamage(gunData.Damage);
            }
            hit.rigidbody?.AddForce(-hit.normal * gunData.KnockbackForce);
        }
    }
}
