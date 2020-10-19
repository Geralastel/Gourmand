using Assets.Scripts.Weapons;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class GenericGun : GenericWeapon<WeaponData>, IGun, IEmitBulletTracerParticle
    {
        private IEnumerator _reload;
        private GunData gunData;

        public int AmmoInClip { get; protected set; }
        public BulletTracersParticleSystem BulletTracersParticleSystem { get; set; }

        private void Awake()
        {
            BulletTracersParticleSystem = GetComponent<BulletTracersParticleSystem>();
        }

        public abstract void Shoot();

        public override void PrimaryAction()
        {
            if (CanShoot())
            {
                Shoot();
                OnAfterShoot();
            }
        }

        public virtual void Reload()
        {
            if (_reload != null)
                StopCoroutine(_reload);

            _reload = DoReload();
            StartCoroutine(_reload);
        }

        public override void Initialize(WeaponData weaponData)
        {
            base.Initialize(weaponData);

            gunData = weaponData as GunData;

            if (gunData == null)
            {
                Debug.LogError($"{gameObject.name}: Missing Gun Data");
            }
            else
            {
                if (gunData.MagazineSize == 0)
                {
                    Debug.LogError($"{gameObject.name}: Magazine Size set to 0");
                }

                if (gunData.ReloadSpeed == 0)
                {
                    Debug.LogError($"{gameObject.name}: Reload speed set to 0");
                }
            }

            AmmoInClip = gunData.MagazineSize;
        }

        public bool CanShoot()
        {
            return gunData.MagazineSize == -1 || AmmoInClip > 0;
        }

        void OnAfterShoot()
        {
            Debug.Log("Ammo removed");
            AmmoInClip--;
        }

        IEnumerator DoReload()
        {
            Debug.Log("WE RELOADING");
            yield return new WaitForSeconds(10 / gunData.ReloadSpeed);
            Debug.Log("AMMO ADDED");
            AmmoInClip = gunData.MagazineSize;
        }
    }
}
