using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerNPC : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private float _offset = 1.5f;

    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();


    }

    void UpdateDestination()
    {
        _agent.destination = _playerTransform.position + new Vector3(_offset, 0, _offset);
    }

    void Update()
    {
        if (_playerTransform.position != _agent.destination)
        {
            UpdateDestination();
        }
    }
}
