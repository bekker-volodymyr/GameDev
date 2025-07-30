using UnityEngine;

public class CollisionDetecter : MonoBehaviour
{
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * 15f, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Відбулось зіткнення з {collision.gameObject.name}!");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log($"Зіткнення все ще відбувається з {collision.gameObject.name}!");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log($"Зіткнення закінчилось з {collision.gameObject.name}!");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Спрацював трігер {other.name}");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"Працює трігер {other.name}");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"Закінчився трігер {other.name}");
    }
}
