using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol : MonoBehaviour
{
    private NavMeshAgent _agent; // Посилання на компонент NavMeshAgent

    [SerializeField]
    private List<Transform> _patrolPoints; // Список точок патрулювання 
    // private Transform[] _patrolPoints; // Може бути масивом

    private int _nextIndex = 0; // Поле для збереження номеру наступної точки

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>(); // Зберігаємо посилання на NavMeshAgent

        UpdateDestination(); // Оновнлюємо пункт призначення
    }

    void Update()
    {
        if (_agent.remainingDistance <= 0.02) // Якщо дійшли до поточного пункту призначення - оновлюємо пункт призначення
        {
            UpdateDestination();
        }
    }

    private void UpdateDestination()
    {
        _agent.destination = _patrolPoints[_nextIndex].position;
        _nextIndex++;

        if (_nextIndex >= _patrolPoints.Count)
        {
            _nextIndex = 0;
        }
    }
}
