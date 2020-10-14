using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [Tooltip("Fire rate is set in rounds per minute")]
    [Range(1, 10)] [SerializeField] float fireRate = 1;
    private float nextFireTime = 0f;

    [Space] [SerializeField] private InputActionAsset playerControls;

    private InputAction shootAction;

    private IGun gun;

    private bool held;

    private IEnumerator shoot;

    private void Awake()
    {
        gun = GetComponent<IGun>();

        var defaultActionMap = playerControls.FindActionMap("Gameplay");

        shootAction = defaultActionMap.FindAction("Shoot");

        shootAction.performed += OnShoot;
        //shootAction.canceled += OnShoot;

        held = false;
    }

    private void OnEnable() => shootAction.Enable();

    private void OnDisable() => shootAction.Disable();

    private bool CanFire()
    {
        return Time.time >= nextFireTime;
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        if (CanFire())
        {
            nextFireTime = Time.time + 1f/fireRate;
            gun.PrimaryAction();
        }

        //if (context.performed)
        //{
        //    var triggerPull = context.ReadValue<float>();
        //    if (triggerPull == 1)
        //    {
        //        held = true;

        //        if (shoot != null)
        //        {
        //            StopCoroutine(shoot);
        //        }
        //        shoot = ShootRoutine();
        //        StartCoroutine(shoot);
        //    }
        //}
        //if (context.canceled)
        //{
        //    held = false;
        //    StopCoroutine(shoot);
        //}
    }

    //private IEnumerator ShootRoutine()
    //{
    //    Debug.Log("SHOOT!");
    //    //yield return new WaitForSeconds(0.15f);
    //    yield return new WaitForFixedUpdate();
    //    while (held)
    //    {
    //        float rof = fireRate > 0 ? 1 / fireRate : 1;
    //        yield return new WaitForSeconds(rof);
    //        Debug.Log("AUTOSHOOT");
    //    }
    //}
}
