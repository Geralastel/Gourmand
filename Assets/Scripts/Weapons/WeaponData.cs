using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "New WeaponData", menuName = "Weapon Data", order = 51)]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] GameObject model;
        [SerializeField] float range;
        [SerializeField] float damage;
        [SerializeField] float knockbackForce;
        [SerializeField] float rateOfFire;

        #region Getters and Setters
        public GameObject Model { get => model; set => model = value; }
        public float Range { get => range; set => range = value; }
        public float Damage { get => damage; set => damage = value; }
        public float KnockbackForce { get => knockbackForce; set => knockbackForce = value; }
        public float RateOfFire { get => rateOfFire; set => rateOfFire = value; }
        #endregion
    }
}
