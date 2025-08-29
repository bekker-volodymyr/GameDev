using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField]
    private Vector3 force;

    // Start викликається один раз перед першим виконанням Update після створення MonoBehaviour
    void Start()
    {
        _rb = GetComponent<Rigidbody>(); // Отримати компонент Rigidbody, прикріплений до цього GameObject

        //System.Random random = new System.Random();
        //random.Next();

        //Vector3 force = new Vector3(x, y, z);

        // Vector3.up (0,1,0) * 5 = (0,5,0)
        _rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        _rb.AddTorque(Vector3.right * 4f, ForceMode.Impulse);
    }

    // Update викликається один раз за кадр
    void Update()
    {
        // Обробка введення від гравця, оновлення зображення та UI
        //_rb.AddForce(force, ForceMode.Force);
    }

    // FixedUpdate викликається 1 раз на фіксований інтервал (за замовчуванням 0.02 с = 50 разів/с)
    private void FixedUpdate()
    {
        // Оновлення фізики, позиції та обертів об'єкта
        _rb.AddForce(force, ForceMode.Force);
    }
}
