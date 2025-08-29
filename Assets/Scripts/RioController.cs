using UnityEngine;
using UnityEngine.InputSystem;

public class RioController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private CharacterController _controller;

    private InputAction _moveAction;

    [SerializeField]
    private float _moveSpeed = 4f;
    [SerializeField]
    private float _rotationSpeed = 5f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();

        _moveAction = InputSystem.actions.FindAction("Move");

        _moveAction.started += SetAnimationStateRun;
        _moveAction.canceled += SetAnimationStateIdle;
    }

    private void Update()
    {
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();

        if (moveInput != Vector2.zero)
        {
            // Зберігаємо оберти камери
            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;

            // Обнуляємо вертикальну складову (щоб персонаж не рухався вгору-вниз)
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            // Визначаємо напрямок руху врахувавши напрямок погляду камери
            Vector3 horizontal = (right * moveInput.x + forward * moveInput.y).normalized;

            _controller.SimpleMove(horizontal * _moveSpeed);

            Quaternion targetRotation = Quaternion.LookRotation(horizontal, Vector3.up);
            // Slerp - розраховує кут оберту для плавного обертання
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void SetAnimationStateIdle(InputAction.CallbackContext context)
    {
        _animator.SetInteger("State", 0);
    }

    private void SetAnimationStateRun(InputAction.CallbackContext context)
    {
        _animator.SetInteger("State", 1);
    }
}
