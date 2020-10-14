using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] float lookSpeed = 1.0f;
    [SerializeField] float moveLookSpeed = 0.15f;

    [Space] [SerializeField] private InputActionAsset playerControls;

    private InputAction lookAction;
    private InputAction moveAction;

    private Rigidbody2D rb;

    private Vector2 movementDirection;
    private Vector2 lookDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        var defaultActionMap = playerControls.FindActionMap("Gameplay");

        moveAction = defaultActionMap.FindAction("Move");
        lookAction = defaultActionMap.FindAction("Look");

        moveAction.performed += OnMovementChanged;
        moveAction.canceled += OnMovementChanged;

        lookAction.performed += OnLookChanged;
        lookAction.canceled += OnLookChanged;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable();
    }

    private void OnMovementChanged(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }

    private void OnLookChanged(InputAction.CallbackContext context)
    {
        lookDirection = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        rb.MovePosition(transform.position + (new Vector3(movementDirection.x, movementDirection.y, transform.position.z) * speed * Time.deltaTime));
    }

    private void Turn()
    {
        if (lookDirection == Vector2.zero)
        {
            if (movementDirection != Vector2.zero)
            {
                var angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), moveLookSpeed);
            }
        }
        else
        {
            var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), lookSpeed);
        }
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }
}
