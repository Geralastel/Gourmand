using Assets.Scripts.Weapons;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [Tooltip("Fire rate is set in rounds per minute")]
    [Range(1, 10)] [SerializeField] float fireRate = 1;

    [Space] [SerializeField] InputActionAsset playerControls;
    public InputActionAsset PlayerControls { get; private set; }

    private InputAction _shootAction;

    private IWeapon _weapon;
    private float _nextFireTime = 0f;
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
