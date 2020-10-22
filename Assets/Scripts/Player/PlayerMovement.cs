using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float speed = 10.0f;
        [SerializeField] float lookSpeed = 1.0f;
        [SerializeField] float moveLookSpeed = 0.15f;

        [Space] [SerializeField] InputActionAsset playerControls;
        public InputActionAsset PlayerControls { get; private set; }

        private InputAction _lookAction;
        private InputAction _moveAction;

        private Rigidbody2D _rb;

        private Vector2 _movementDirection;
        private Vector2 _lookDirection;

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

            _rb = GetComponent<Rigidbody2D>();
            var defaultActionMap = PlayerControls.FindActionMap("Standard");

            _moveAction = defaultActionMap.FindAction("Move");
            _lookAction = defaultActionMap.FindAction("Look");

            _moveAction.performed += OnMovementChanged;
            _moveAction.canceled += OnMovementChanged;

            _lookAction.performed += OnLookChanged;
            _lookAction.canceled += OnLookChanged;
        }

        private void OnEnable()
        {
            _moveAction.Enable();
            _lookAction.Enable();
        }

        private void OnDisable()
        {
            _moveAction.Disable();
            _lookAction.Disable();
        }

        private void OnMovementChanged(InputAction.CallbackContext context)
        {
            _movementDirection = context.ReadValue<Vector2>();
        }

        private void OnLookChanged(InputAction.CallbackContext context)
        {
            _lookDirection = context.ReadValue<Vector2>();
        }

        private void Move()
        {
            _rb.MovePosition(transform.position + (new Vector3(_movementDirection.x, _movementDirection.y, transform.position.z) * speed * Time.deltaTime));
        }

        private void Turn()
        {
            if (_lookDirection == Vector2.zero)
            {
                if (_movementDirection != Vector2.zero)
                {
                    var angle = Mathf.Atan2(_movementDirection.y, _movementDirection.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), moveLookSpeed);
                }
            }
            else
            {
                var angle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), lookSpeed);
            }
        }

        private void FixedUpdate()
        {
            Move();
            Turn();
        }
    }

}