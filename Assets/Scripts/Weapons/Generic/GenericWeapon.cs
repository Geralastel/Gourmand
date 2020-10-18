using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class GenericWeapon<T> : MonoBehaviour, IWeapon where T : WeaponData
    {
        public T weaponData;

        [SerializeField] protected LayerMask collisionLayer;
//#pragma warning disable CS0649
//        [SerializeField] private Transform weaponModelTransformParent;
//#pragma warning restore CS0649

        protected GameObject _prefab;

        public abstract void PrimaryAction();
        public abstract void SecondaryAction();

        private void OnEnable()
        {
            if (_prefab != null)
            {
                var parent = transform.parent;
                Destroy(_prefab);

                if (weaponData.Prefab != null)
                {
                    _prefab = Instantiate(weaponData.Prefab, parent);
                }
            }
        }

        public virtual void Initialize(T weaponData)
        {
            this.weaponData = weaponData;

            if (collisionLayer == 0)
            {
                Debug.LogError($"{gameObject.name}: Collision Layer set to Nothing");
            }

            //if (weaponModelTransformParent == null)
            //{
            //    Debug.LogError($"{gameObject.name}: Missing model transform parent");
            //}
        }
    }
}
