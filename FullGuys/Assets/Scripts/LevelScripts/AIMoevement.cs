using UnityEngine;
using UnityEngine.AI;

public class AIMoevement : MonoBehaviour
{
    //[SerializeField] public List<GameObject> wayPoints;
    //private NavMeshAgent _agent;
    //private GameObject _target;
    //private int index = 0;

    //void Start()
    //{
    //    _agent = GetComponent<NavMeshAgent>();
    //    _target = GameObject.FindGameObjectWithTag("Finish");
    //    SetRandomDestination();
    //    SetDestinationToTarget();
    //}

    //void Update()
    //{
    //    SetPoints(transform);
    //    if (_target.transform.hasChanged)
    //    {
    //        SetDestinationToTarget();
    //        _target.transform.hasChanged = false;
    //    }
    //}
    //public void SetPoints(Transform transform)
    //{
    //    Vector3 destination = wayPoints[index].transform.position;
    //    Vector3 newPos = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
    //    transform.position = newPos;

    //    float distance = Vector3.Distance(transform.position, destination);
    //    if (distance <= .05)
    //    {
    //        if (index < wayPoints.Count - 1)
    //        {
    //            index++;
    //        }
    //    }
    //}

    //private void SetDestinationToTarget()
    //{

    //    if (_target != null)
    //    {
    //        _agent.SetDestination(_target.transform.position);
    //    }
    //    else
    //    {
    //        print("error");
    //    }
    //}

    //private void SetRandomDestination()
    //{
    //    int randomRoute = Random.Range(1, 3);
    //    if (randomRoute == 1)
    //    {
    //        //route 1
    //    }
    //    else
    //    {
    //        //route 2
    //    }
    //}
}
