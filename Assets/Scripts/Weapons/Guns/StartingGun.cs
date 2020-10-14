using UnityEngine;

namespace Assets.Scripts.Guns
{
    public class StartingGun : Gun
    {
        GameObject weaponParent; 
        private void Awake()
        {
            // set sprite

        }
        public override void PrimaryAction()
        {
            ShootHelper.RayCastShoot(transform.position, transform.right, collisionLayer, gunData);
        }

        public override void Reload()
        {
            throw new System.NotImplementedException();
        }

        public override void SecondaryAction()
        {
            throw new System.NotImplementedException();
        }
    }
}
