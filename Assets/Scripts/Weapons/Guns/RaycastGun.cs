using Assets.Scripts.Entity;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class RaycastGun : GenericGun
    {
        // add a emitter for bullet line
        public override void SecondaryAction() { }

        public override void Shoot()
        {
            BulletTracersParticleSystem?.EmitBulletTracer();

            RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.25f, transform.right, WeaponRange, CollisionLayer);
            Debug.DrawRay(transform.position, transform.right * WeaponRange, Color.red, 20f);
            var hitDireciton = -hit.normal;
            if (hit.collider)
            {
                var target = hit.collider.GetComponent<IDamageable>();
                target?.TakeDamage(Damage, hitDireciton);
            }
            hit.rigidbody?.AddForce(hitDireciton * KnockbackForce);
        }
    }
}
