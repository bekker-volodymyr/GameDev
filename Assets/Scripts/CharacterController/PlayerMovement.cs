using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Посилання на компонент CharacterController
    CharacterController _controller;

    // Дії - зчитуємо вхідні дані з Input System (клавіатура, геймпад)
    InputAction _moveAction;
    InputAction _jumpAction;

    // Поле для зберігання напрямку руху
    Vector3 _direction;
    float _vertical;

    [SerializeField]
    float _speed = 5f;
    [SerializeField]
    float _rotationSpeed = 6f;
    [SerializeField]
    float _jumpForce = 5f;

    // Гравітація, яка буде застосовуватись до персонажа
    // CharacterController не має фізики та не сумісний з Rigidbody, тому ми застосовуємо гравітацію вручну
    float _gravity = -9.81f;

    void Start()
    {
        // Отримуємо компонент CharacterController, який повинен бути на цьому об'єкті
        _controller = GetComponent<CharacterController>();

        // Переконуємось, що контролер на землі - прижимаємо його до землі, рух вниз
        _controller.Move(new Vector3(0f, -2f, 0f));

        // Ініціалізуємо дію руху з Input System
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");

        // _jumpAction.performed += ctx => Jump(); обробляємо вручну в Update
    }

    void Update()
    {
        // Отримуємо вхідні дані руху
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        // Визначаємо напрямок руху на основі вхідних даних
        Vector3 horizontal = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

        // Якщо була натиснута кнопка стрибка, викликаємо метод Jump
        if (_jumpAction.triggered)
        {
            Jump();
        }

        // Враховуємо гравітацію, додаючи її до вертикальної складової руху
        _vertical += _gravity * Time.deltaTime;

        _direction = horizontal;

        // Зберігаємо вертикальну складову руху
        _direction.y = _vertical;

        // Рухаємо персонажа за допомогою CharacterController
        // Time.deltaTime та гравітація не варховуються автоматично у методі Move
        _controller.Move(_direction * Time.deltaTime * _speed);

        // Якщо присутній горизонтальний рух - обератємо персонажа в напрямку руху
        if (horizontal != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(horizontal, Vector3.up);
            // Slerp - розраховує кут оберту для плавного обертання
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }

        // Гравітація та Time.deltaTime застосовуються автоматично
        // Y-координата вектору _direction ігнорується методом SimpleMove
        // _controller.SimpleMove(_direction * _speed);
    }

    void Jump()
    {
        // Перевіряємо, чи персонаж на землі - щоб уникнути подвійного стрибку
        if (_controller.isGrounded)
        {
            // Додаємо силу стрибка
            _vertical = _jumpForce;
        }
    }
}
