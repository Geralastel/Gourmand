using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "New GunData", menuName = "Gun Data", order = 51)]
    public class GunData : WeaponData
    {
        [SerializeField] private int magazineSize;
        [SerializeField] private float reloadSpeed;

        #region Getters and Setters
        public int MagazineSize { get => magazineSize; set => magazineSize = value; }
        public float ReloadSpeed { get => reloadSpeed; set => reloadSpeed = value; }
        #endregion
    }
}
