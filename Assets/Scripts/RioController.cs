using UnityEngine;
using UnityEngine.InputSystem;

public class RioController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private InputAction _moveInput;

    void Start()
    {
        _moveInput = InputSystem.actions.FindAction("Move");

        _moveInput.started += SetAnimationStateRun;
        _moveInput.canceled += SetAnimationStateIdle;
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
