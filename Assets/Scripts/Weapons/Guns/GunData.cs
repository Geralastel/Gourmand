using UnityEngine;

namespace Assets.Scripts.Guns
{
    [CreateAssetMenu(fileName = "New GunData", menuName = "Gun Data", order = 52)]
    public class GunData : WeaponData
    {
        [SerializeField] int magazineSize;
        [SerializeField] float reloadSpeed;

        #region Getters and Setters
        public int MagazineSize { get => magazineSize; set => magazineSize = value; }
        public float ReloadSpeed { get => reloadSpeed; set => reloadSpeed = value; }
        #endregion
    }
}
