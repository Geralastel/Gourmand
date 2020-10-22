using Assets.Scripts.Managers;
using Assets.Scripts.Weapons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [Space] [SerializeField] InputActionAsset playerControls;
        public InputActionAsset PlayerControls { get; private set; }

        private InputAction _shootAction;
        private InputAction _reloadAction;

        private IWeapon _weapon;
        private float _nextFireTime = 0f;
        private bool _isReloading;
        private bool _held;

        private void Awake()
        {
            if (playerControls)
            {
                PlayerControls = playerControls;
            }
            else
            {
                Debug.LogError($"ERROR: Missing InputActionAsset in {gameObject.name}");
            }

            var defaultActionMap = PlayerControls.FindActionMap("Standard");

            _shootAction = defaultActionMap.FindAction("Shoot");

            _shootAction.performed += HandleShoot;
            //shootAction.canceled += OnShoot;

            _reloadAction = defaultActionMap.FindAction("Reload");

            _reloadAction.performed += HandleReload;

            _held = false;
        }

        private void Start()
        {
            _weapon = GetComponentInChildren<IWeapon>();
        }

        private void OnEnable()
        {
            _shootAction.Enable();
            _reloadAction.Enable();
            EventManager.StartListening(Events.Reload, SetReloadingState);
        }

        private void OnDisable()
        {
            _shootAction.Disable();
            _reloadAction.Disable();
            EventManager.StopListening(Events.Reload, SetReloadingState);
        }

        private bool CanFire()
        {
            return Time.time >= _nextFireTime && !_isReloading;
        }

        private void HandleShoot(InputAction.CallbackContext context)
        {
            if (CanFire() && !_isReloading)
            {
                EventManager.TriggerEvent(Events.Shoot);
                
                _nextFireTime = Time.time + 1f/_weapon.RateOfFire;
                _weapon.PrimaryAction();
            }
        }

        private void HandleReload(InputAction.CallbackContext obj)
        {
            if (_weapon is IGun gun && !_isReloading)
            {
                _isReloading = true;
                gun.Reload();
            }
        }

        private void SetReloadingState()
        {
            _isReloading = !_isReloading;
        }
    }

}