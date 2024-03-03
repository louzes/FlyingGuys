using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMoevement : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private Transform _goPoint;

    void Start() => _agent = GetComponent<NavMeshAgent>();

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_goPoint.position);
    }
}
