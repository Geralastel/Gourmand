using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float range;
        [SerializeField] private float damage;
        [SerializeField] private float knockbackForce;
        [SerializeField] private float rateOfFire;

        #region Getters and Setters
        public GameObject Prefab { get => prefab; set => prefab = value; }
        public float Range { get => range; set => range = value; }
        public float Damage { get => damage; set => damage = value; }
        public float KnockbackForce { get => knockbackForce; set => knockbackForce = value; }
        public float RateOfFire { get => rateOfFire; set => rateOfFire = value; }
        #endregion
    }
}
