using System.Collections.Generic;
using UnityEngine;

public class SpecialMovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; // Швидкість руху платформи

    [SerializeField]
    private List<Vector3> waypoints; // Перелік точок в які платформа повинна рухатись

    private Vector3 startPoint; // Стартова точка
    private int currentWaypointIndex = 0; // Індекс точки в яку платформа рухається зараз

    void Start()
    {
        // Зберігаємо стартову точку
        startPoint = transform.position;

        // Додаємо стартову позицію як початковий вейпойнт, якщо список порожній
        if (waypoints == null || waypoints.Count == 0)
        {
            waypoints = new List<Vector3> { startPoint };
        }
    }

    void Update()
    {
        // Якщо немає точок для руху - не виконуємо Update
        if (waypoints.Count == 0)
            return;

        // Отримуємо поточну цільову позицію
        Vector3 target = startPoint + waypoints[currentWaypointIndex];

        // Рухаємось до цільової позиції
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Якщо дійшли до цільової позиції — переходимо до наступної
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }
    }
}
