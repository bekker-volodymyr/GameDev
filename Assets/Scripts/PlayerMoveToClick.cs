using UnityEngine;
using UnityEngine.AI;

public class PlayerMoveToClick : MonoBehaviour
{
    private NavMeshAgent _agent; // Посилання на компонент NavMeshAgent

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                _agent.destination = hit.point;
            }
        }
    }
}
