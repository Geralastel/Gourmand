using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] GameObject weaponPrefab;
        [SerializeField] Transform weaponModelTransformParent;

        public GameObject WeaponPrefab { get; private set; }
        public Transform WeaponModelTransformParent { get; private set; }

        private PlayerCrosshair _crosshair;
        private IWeapon _equipedWeapon;

        private void Awake()
        {
            _crosshair = GetComponent<PlayerCrosshair>();
            if (_crosshair == null)
            {
                Debug.LogError($"Could not find PlayerCrosshair component in {gameObject.name}");
            }
            Initialize();
        }

        public void Initialize()
        {
            if (weaponPrefab)
            {
                WeaponPrefab = weaponPrefab;
            }
            else
            {
                Debug.LogError($"Missing WeaponPrefab in {gameObject.name}");
            }

            if (weaponModelTransformParent)
            {
                WeaponModelTransformParent = weaponModelTransformParent;
            }
            else
            {
                Debug.LogError($"Missing WeaponModelTransformParent in {gameObject.name}");
            }

            _equipedWeapon = Instantiate(weaponPrefab, weaponModelTransformParent).GetComponent<IWeapon>();
            if (_equipedWeapon == null)
            {
                Debug.LogError($"Missing Weapon Component in {gameObject.name}");
            }

            _crosshair.Initialize(_equipedWeapon.WeaponRange);
        }
    }
}
