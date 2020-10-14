using UnityEngine;

namespace Assets.Scripts.Guns
{
    [CreateAssetMenu(fileName = "New GunData", menuName = "Gun Data", order = 52)]
    public class GunData : WeaponData
    {
        [SerializeField] int magazineSize;

        #region Getters and Setters
        public int MagazineSize { get => magazineSize; set => magazineSize = value; }
        #endregion
    }
}
