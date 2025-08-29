using UnityEngine;
using UnityEngine.AI;

public class NPCMoveToPoint : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField]
    private Transform _targetTransform;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _agent.destination = _targetTransform.position;
    }

    void Update()
    {

    }
}
