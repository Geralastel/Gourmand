using Assets.Scripts.Guns;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Gun : MonoBehaviour, IGun
    {
        [SerializeField] protected LayerMask collisionLayer;
        [SerializeField] protected GunData gunData;

        [SerializeField] private Transform weaponModelTransformParent;

        private GameObject model;

        public abstract void PrimaryAction();
        public abstract void SecondaryAction();
        public abstract void Reload();

        private void OnEnable()
        {
            if (model != null) Destroy(model);

            if (gunData.Model != null)
            {
                model = Instantiate(gunData.Model);
                model.transform.SetParent(weaponModelTransformParent, false);
            }
        }

        private void Awake()
        {
            if (gunData == null)
            {
                Debug.LogError($"{gameObject.name}: Missing Gun Data");
            }
            if (collisionLayer == 0)
            {
                Debug.LogError($"{gameObject.name}: Collision Layer set to Nothing");
            }
        }
    }
}
