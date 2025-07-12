using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float offset = 5.85f;
    private Vector3 startPosition;
    private Vector3 direction;

    private void Start()
    {
        // Зберігаємо початкову позицію платформи
        startPosition = transform.position;
        // Встановлюємо початковий напрямок руху платформи
        direction = Vector3.right;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, startPosition) >= offset)
        {
            float coord = transform.position.x > startPosition.x ? offset : -offset;
            transform.position = new Vector3(startPosition.x + coord, transform.position.y, transform.position.z);

            // Змінюємо напрямок руху платформи
            direction *= -1;
            // (1, 0, 0) * -1 = (-1, 0, 0)
            // (-1, 0, 0) * -1 = (1, 0, 0)
            // speed *= -1;
        }

        // Завдання 1: Змінити створений сценарій платформи так, щоб напрямок руху можна було налаштувати в інспекторі Unity.
        // Завдання 2: Створити платформу, яка рухається по зазначеним точкам.*
    }
}
