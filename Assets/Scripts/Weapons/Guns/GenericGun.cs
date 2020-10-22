using Assets.Scripts.Managers;
using Assets.Scripts.Particles;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class GenericGun : GenericWeapon<GunData>, IGun, IEmitBulletTracerParticle
    {
        public int AmmoInClip { get; protected set; }
        public BulletTracersParticleSystem BulletTracersParticleSystem { get; set; }

        public int MagazineSize { get; private set; }

        public float ReloadSpeed { get; private set; }

        private IEnumerator _reload;

        private void Awake()
        {
            BulletTracersParticleSystem = GetComponent<BulletTracersParticleSystem>();
            Initialize();
        }

        public abstract void Shoot();

        public override void GenerateStats()
        {
            base.GenerateStats();

            MagazineSize = Random.Range(WeaponData.MinMagazineSize, WeaponData.MaxMagazineSize);
            ReloadSpeed = Random.Range(WeaponData.MinReloadSpeed, WeaponData.MaxReloadSpeed);
            AmmoInClip = MagazineSize;
        }

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

        public bool CanShoot()
        {
            return MagazineSize == -1 || AmmoInClip > 0;
        }

        void OnAfterShoot()
        {
            AmmoInClip--;
        }

        IEnumerator DoReload()
        {
            yield return new WaitForSeconds(1 / ReloadSpeed);
            AmmoInClip = MagazineSize;
            EventManager.TriggerEvent(Events.Reload);
        }
    }
}
