using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Rigidbody _rb; // Rigidbody для керування фізикою куба

    [SerializeField]
    private float _force = 5f; // Сила, яку будемо застосовувати до куба

    void Start()
    {
        _rb = GetComponent<Rigidbody>(); // Отримуємо компонент Rigidbody

       //_rb.AddForce(Vector3.up * 5f, ForceMode.Impulse); // Додаємо силу до куба
       //_rb.AddTorque(Vector3.forward * 5f, ForceMode.Impulse); // Додаємо обертання до куба
    }

    void Update()
    {
        _rb.AddForce(Vector3.right * _force, ForceMode.Force); // Додаємо постійну силу вправо
    }
}
