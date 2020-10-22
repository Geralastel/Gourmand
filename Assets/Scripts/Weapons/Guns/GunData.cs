using UnityEngine;

namespace Assets.Scripts.Weapons
{
    [CreateAssetMenu(fileName = "New GunData", menuName = "Gun Data", order = 51)]
    public class GunData : WeaponData
    {
        [Space]
        [Min(1)] [SerializeField] private int minMagazineSize;
        [Min(1)] [SerializeField] private int maxMagazineSize;
        [Space]
        [Range(1,10)] [SerializeField] private float minReloadSpeed;
        [Range(1,10)] [SerializeField] private float maxReloadSpeed;

        #region Getters and Setters
        public int MinMagazineSize { get => minMagazineSize; private set => minMagazineSize = value; }
        public int MaxMagazineSize { get => maxMagazineSize; private set => maxMagazineSize = value; }
        public float MinReloadSpeed { get => minReloadSpeed; private set => minReloadSpeed = value; }
        public float MaxReloadSpeed { get => maxReloadSpeed; private set => maxReloadSpeed = value; }
        #endregion
    }
}
