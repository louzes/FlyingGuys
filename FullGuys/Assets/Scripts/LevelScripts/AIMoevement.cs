using UnityEngine;
using UnityEngine.AI;

public class AIMoevement : MonoBehaviour
{
    [SerializeField] private Transform _goPoint;
    private NavMeshAgent _agent;

    void Start() => _agent = GetComponent<NavMeshAgent>();

    void Update()
    {
        _agent.SetDestination(_goPoint.position);
    }
}
