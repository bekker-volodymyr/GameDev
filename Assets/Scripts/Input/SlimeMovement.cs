using UnityEngine;
using UnityEngine.InputSystem;

public class SlimeMovement : MonoBehaviour
{
    Rigidbody _rb;

    InputAction _moveAction;
    InputAction _jumpAction;
    InputAction _dashAction;

    Vector3 _direction;

    [SerializeField]
    float _speed = 5f;
    [SerializeField]
    float _jumpForce = 5f;
    [SerializeField]
    float _dashForce = 7f;

    bool _isGrounded = true;
    bool _canDash = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _dashAction = InputSystem.actions.FindAction("Dash");

        _jumpAction.performed += ctx => Jump();
        _dashAction.performed += ctx => Dash();
    }

    void Update()
    {
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        _direction = new Vector3(moveInput.x, 0f, moveInput.y).normalized;
    }

    private void FixedUpdate()
    {
        if (_direction != Vector3.zero)
        {
            _rb.MovePosition(
                _rb.position + _direction * _speed * Time.fixedDeltaTime
            );
        }
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void Dash()
    {
        if (_canDash && !_isGrounded)
        {
            _canDash = false;
            Vector3 dashDirection = _direction * _dashForce;
            _rb.AddForce(dashDirection, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
        _canDash = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
}

