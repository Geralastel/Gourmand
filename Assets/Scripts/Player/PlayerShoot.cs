using Assets.Scripts.Weapons;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [Tooltip("Fire rate is set in rounds per minute")]
    [Range(1, 10)] [SerializeField] float fireRate = 1;

#pragma warning disable CS0649
    [Space] [SerializeField] InputActionAsset playerControls;
#pragma warning restore CS0649

    private InputAction _shootAction;

    private IWeapon _weapon;
    private float _nextFireTime = 0f;
    private bool _held;

    private void Awake()
    {
        var defaultActionMap = playerControls.FindActionMap("Standard");

        _shootAction = defaultActionMap.FindAction("Shoot");

        _shootAction.performed += OnShoot;
        //shootAction.canceled += OnShoot;

        _held = false;
    }

    private void Start()
    {
        _weapon = GetComponentInChildren<IWeapon>();
    }

    private void OnEnable() => _shootAction.Enable();

    private void OnDisable() => _shootAction.Disable();

    private bool CanFire()
    {
        return Time.time >= _nextFireTime;
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        if (CanFire())
        {
            _nextFireTime = Time.time + 1f / fireRate;
            _weapon.PrimaryAction();
        }
    }
}
