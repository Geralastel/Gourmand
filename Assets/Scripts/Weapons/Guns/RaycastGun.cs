using UnityEngine;

namespace Assets.Scripts.Weapons.Guns
{
    public class RaycastGun : Gun
    {
        // add a emitter for bullet line
        public override void SecondaryAction() { }

        public override void Shoot()
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.5f, transform.right, weaponData.Range, collisionLayer);
            Debug.DrawRay(transform.position, transform.right * weaponData.Range, Color.red, 20f);
            var hitDireciton = -hit.normal;
            if (hit.collider)
            {
                var target = hit.collider.GetComponent<IDamageable>();
                target?.TakeDamage(weaponData.Damage, hitDireciton);
            }
            hit.rigidbody?.AddForce(hitDireciton * weaponData.KnockbackForce);
        }
    }
}
