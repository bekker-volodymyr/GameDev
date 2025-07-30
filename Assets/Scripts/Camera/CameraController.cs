using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    // Посилання на об'єкт гравця - ціль, за якою рухається камера
    [SerializeField]
    private Transform _target;
    // Зміщення камери відносно об'єкта гравця
    [SerializeField]
    private Vector3 _offset = new Vector3(0f, 4f, -5f);
    // Швидкість плавного руху камери за гравцем
    [SerializeField]
    private float _smoothSpeed = 5f;

    [SerializeField]
    private Vector2 _sensativity = new Vector2(100f, 80f);

    // Межові значення для тангажу (відхиленню по вертикалі)
    [SerializeField]
    private float _minPitch = -36f;
    [SerializeField]
    private float _maxPitch = 40f;

    // Відхилення по горизонталі (навколо вісі Y, вліво-вправо)
    float _yaw = 0f;
    // Відхилення по вертикалі (навколо вісі X, вгору-вниз)
    float _pitch = 0f;

    // Посилання на дію з InputSystem (введення миші, правий стік геймпаду)
    InputAction _lookAction;

    void Start()
    {
        // Встановлюємо стартову позицію камери - позиція персонажа + зміщення
        transform.position = _target.position + _offset;
        // Змушуємо камеру дивитись на персонажа
        // Метод LookAt повртає об'єкт так, щоб Vector.forward вказував на позицію _target
        transform.LookAt(_target);

        // Зберігаємо посилання на дію Look
        _lookAction = InputSystem.actions.FindAction("Look");
    }

    // Оновлюємо позицію камери у LateUpdate
    // LateUpdate викликається на кожному кадрі після того, як всі методи Update відпрацюють
    // Персонаж рухається у Update, а камера повинна рухатись після руху персонажу - тому рухаємо камеру у LateUpdate
    void LateUpdate()
    {
        // Отримуємо вектор введення мишки (або геймпаду)
        Vector2 lookInput = _lookAction.ReadValue<Vector2>();

        // Розраховуємо оберти по двом вісям
        _yaw += lookInput.x * _sensativity.x * Time.deltaTime;
        _pitch -= lookInput.y * _sensativity.y * Time.deltaTime;

        // Розраховуємо оберти по двом вісям (без чутливості миші)
        // _yaw += lookInput.x * Time.deltaTime;
        // _pitch -= lookInput.y * Time.deltaTime;

        // Обмежуємо обертання по вертикалі (навколо вісі X)
        // Clamp - метод який повертає значення першого параметру в межі, задані другим і третім параметрами
        // Якщо значення першого параметру менше за другий параметр - повертає значення другого параметру (мінімуму)
        // Якщо значення більше за третій параметр - повертає значення третього параметру (максимуму)
        // Якщо значення більше мінімуму та менше максимуму (в заданих межах) - повертає саме значення
        _pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch);

        // Розраховуємо кути обертів
        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0f);

        // Розраховуємо позицію камери - позиція персонажа + зміщення
        Vector3 desiredPosition = _target.position + (rotation * _offset);
        // Переставляємо камеру в нову точку (без зглажування)
        // transform.position = desiredPosition;
        // Lerp - допомагає розрахувати плавний рух
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
        // Змушуємо камеру дивитись на персонажа
        transform.LookAt(_target);
    }

}
