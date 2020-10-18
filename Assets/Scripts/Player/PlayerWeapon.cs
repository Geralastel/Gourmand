using Assets.Scripts.Factory;
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerWeapon : MonoBehaviour
    {
        public GenericWeapon<WeaponData> EquipedWeapon {get;set;}

#pragma warning disable CS0649
        [SerializeField] WeaponData weaponData;
        [SerializeField] Transform weaponModelTransformParent;
        [SerializeField] WeaponFactory factory;
#pragma warning restore CS0649

        private PlayerCrosshair _crosshair;

        private void Awake()
        {
            _crosshair = GetComponent<PlayerCrosshair>();
        }

        private void Start()
        {
            Initialize();
        }

        private void OnEnable()
        {
            if (EquipedWeapon != null)
            {
                Destroy(EquipedWeapon.gameObject);
                EquipedWeapon = factory.Create(weaponData).GetComponent<GenericWeapon<WeaponData>>();
            }
        }

        public void Initialize()
        {
            EquipedWeapon = factory.Create(weaponData, weaponModelTransformParent).GetComponent<GenericWeapon<WeaponData>>();
            EquipedWeapon.Initialize(weaponData);

            _crosshair.Initialize(weaponData);
         }
    }
}
