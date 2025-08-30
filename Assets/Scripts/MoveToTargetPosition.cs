using UnityEngine;
using UnityEngine.AI;

public class MoveToTargetPosition : MonoBehaviour
{
    private NavMeshAgent _agent; // Посилання на компонент NavMeshAgent

    [SerializeField]
    private Transform _targetPosition; // Позиція в яку рухається персонаж

    void Start()
    {
        // Посилання на navmesh агента (компонент)
        _agent = GetComponent<NavMeshAgent>();

        // Встановлюємо пункт призначення
        // В цей момент Unity починає розрахунок найкоротшого шляху в задану точку
        // Щойно шлях буде розрахований персонаж почне рухатись автоматично
        _agent.destination = _targetPosition.position;

        // _agent.remainingDistance
        // Реалізувати персонажа, що патрулюює список точок
    }
}
