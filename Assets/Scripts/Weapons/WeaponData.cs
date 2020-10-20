using Assets.Scripts.Entity;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class WeaponData : ScriptableObject, IHasSprite
    {
        [SerializeField] Sprite sprite;
        [Space]
        [Min(1)] [SerializeField] float minWeaponRange;
        [Min(1)] [SerializeField] float maxWeaponRange;
        [Space]
        [Min(1)] [SerializeField] int minDamage;
        [Min(1)] [SerializeField] int maxDamage;
        [Space]
        [Min(1)] [SerializeField] float minKnockbackForce;
        [Min(1)] [SerializeField] float maxKnockbackForce;
        [Space]
        [Min(1)] [SerializeField] float minRateOfFire;
        [Min(1)] [SerializeField] float maxRateOfFire;

        #region Getters and Setters
        public Sprite Sprite { get => sprite; private set => sprite = value; }
        public float MinWeaponRange { get => minWeaponRange; private set => minWeaponRange = value; }
        public float MaxWeaponRange { get => maxWeaponRange; private set => maxWeaponRange = value; }
        public int MinDamage { get => minDamage; private set => minDamage = value; }
        public int MaxDamage { get => maxDamage; private set => maxDamage = value; }
        public float MinKnockbackForce { get => minKnockbackForce; private set => minKnockbackForce = value; }
        public float MaxKnockbackForce { get => maxKnockbackForce; private set => maxKnockbackForce = value; }
        public float MinRateOfFire { get => minRateOfFire; private set => minRateOfFire = value; }
        public float MaxRateOfFire { get => maxRateOfFire; private set => maxRateOfFire = value; }
        #endregion
    }
}