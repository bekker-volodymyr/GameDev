using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody _rb;

    private Vector3 _direction;

    [SerializeField]
    private float _speed = 5f;

    private bool _isGrounded = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _direction = new Vector3(
            Input.GetAxis("Horizontal"),
            0f,
            Input.GetAxis("Vertical")
        ).normalized;

        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if(_direction != Vector3.zero)
        {
            //_rb.AddForce(_direction * _speed, ForceMode.VelocityChange);

            _rb.MovePosition(
                _rb.position + _direction * _speed * Time.fixedDeltaTime
            );
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
}
