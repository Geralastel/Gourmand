using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerWeapon : MonoBehaviour
    {

#pragma warning disable CS0649
        [SerializeField] GameObject weaponPrefab;
        [SerializeField] Transform weaponModelTransformParent;
#pragma warning restore CS0649

        private PlayerCrosshair _crosshair;
        private IWeapon _equipedWeapon;

        private void Awake()
        {
            _crosshair = GetComponent<PlayerCrosshair>();
            Initialize();
        }

        public void Initialize()
        {
            _equipedWeapon = Instantiate(weaponPrefab, weaponModelTransformParent).GetComponent<IWeapon>();
            if (_equipedWeapon == null)
            {
                Debug.LogError($"Missing Weapon Component in {gameObject.name}");
            }

            _crosshair.Initialize(_equipedWeapon.WeaponRange);
         }
    }
}
