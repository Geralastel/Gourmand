using Assets.Scripts.Guns;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Gun : MonoBehaviour, IGun
    {
        public GunData gunData;

        [SerializeField] protected LayerMask collisionLayer;

        [SerializeField] private Transform weaponModelTransformParent;

        private GameObject _model;
        private IEnumerator _reload;

        public int AmmoInClip { get; protected set; }

        public abstract void SecondaryAction();
        public abstract void Shoot();

        public virtual void PrimaryAction()
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

        private void OnEnable()
        {
            if (_model != null) Destroy(_model);

            if (gunData.Model != null)
            {
                _model = Instantiate(gunData.Model);
                _model.transform.SetParent(weaponModelTransformParent, false);
            }
        }

        private void Awake()
        {
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

            if (collisionLayer == 0)
            {
                Debug.LogError($"{gameObject.name}: Collision Layer set to Nothing");
            }

            if (weaponModelTransformParent == null)
            {
                Debug.LogError($"{gameObject.name}: Missing model transform parent");
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
