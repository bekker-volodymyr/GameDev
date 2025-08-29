using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolNPC : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField]
    private List<Transform> _patrolPoints = new List<Transform>();

    private int _nextPointIndex = 0;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (i.e. the agent doesn't slow down as it
        // approaches a destination point).
        _agent.autoBraking = false;

        GoToNextPoint();
    }

    private void GoToNextPoint()
    {
        _agent.destination = _patrolPoints[_nextPointIndex].position;
        _nextPointIndex++;

        if (_nextPointIndex >= _patrolPoints.Count)
        {
            _nextPointIndex = 0;
        }
    }

    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
            GoToNextPoint();
    }
}
