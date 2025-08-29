using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleContoller : MonoBehaviour
{
    private Rigidbody rb;

    private InputAction moveAction;
    private InputAction jumpAction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");

        jumpAction.performed += Jump;
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void Jump(InputAction.CallbackContext context)
    {
        // Jump logic
    }

    void Update()
    {
        // Vector2.x -> Vector3.x;
        // Vector2.y -> Vector3.z;
        // Vector3.y = 0f;
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
    }
}
