using Assets.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [Tooltip("Fire rate is set in rounds per minute")]
    [Range(1, 10)] [SerializeField] float fireRate = 1;

    [Space] [SerializeField] InputActionAsset playerControls;

    private InputAction _shootAction;

    private IGun _gun;
    private float _nextFireTime = 0f;
    private bool _held;

    private void Awake()
    {
        _gun = GetComponent<IGun>();

        var defaultActionMap = playerControls.FindActionMap("Gameplay");

        _shootAction = defaultActionMap.FindAction("Shoot");

        _shootAction.performed += OnShoot;
        //shootAction.canceled += OnShoot;

        _held = false;
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
            _gun.PrimaryAction();
        }
    }
}
