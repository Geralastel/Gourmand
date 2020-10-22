using Assets.Scripts.Entity;
using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class GenericWeapon<T> : MonoBehaviour, IWeapon, IRandomStats where T : WeaponData
    {
        [SerializeField] T weaponData;
        [SerializeField] LayerMask collisionLayer;

        public T WeaponData { get; private set; }
        public LayerMask CollisionLayer { get; private set; }
        public SpriteManager SpriteManager { get; private set; }
        public Sprite Sprite { get; private set; }
        public float WeaponRange { get; private set; }
        public float Damage { get; private set; }
        public float KnockbackForce { get; private set; }
        public float RateOfFire { get; private set; }

        public abstract void PrimaryAction();
        public abstract void SecondaryAction();

        public SpriteRenderer GetRenderer()
        {
            SpriteRenderer ren = GetComponent<SpriteRenderer>();
            if(ren == null)
            {
                Debug.Log($"ERROR: Could not find spriterendered in {gameObject.name}");
            }
            return ren;
        }

        private void Awake()
        {
            Initialize();
        }

        public virtual void GenerateStats()
        {
            Sprite = weaponData.Sprite;
            WeaponRange = Random.Range(weaponData.MinWeaponRange, weaponData.MaxWeaponRange);
            Damage = Random.Range(weaponData.MinDamage, weaponData.MaxDamage);
            KnockbackForce = Random.Range(weaponData.MinKnockbackForce, weaponData.MaxKnockbackForce);
            RateOfFire = Random.Range(weaponData.MinRateOfFire, weaponData.MaxRateOfFire);
            Debug.Log($"Rate of fire{RateOfFire}");
        }

        public virtual void Initialize()
        {
            SpriteManager = new SpriteManager(GetRenderer(), weaponData);
            SpriteManager.SetSprite();

            if (weaponData == null)
            {
                Debug.LogError($"{gameObject.name}: Missing Weapon Data");
            }

            if (collisionLayer == 0)
            {
                Debug.LogError($"{gameObject.name}: Collision Layer set to Nothing");
            }

            WeaponData = weaponData;
            CollisionLayer = collisionLayer;

            GenerateStats();
        }
    }
}
