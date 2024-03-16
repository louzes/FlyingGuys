using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float _speed;
    private WayPoints Way;

    private List<GameObject> wayPoints;
    private int index = 0;
    

    private void Start()
    {
        Way = FindObjectOfType<WayPoints>();       
        SetRandomDestination();
        SetRandomSpeed();
    }
    private void FixedUpdate()
    {
        SetPoints(transform);
        transform.rotation = Quaternion.LookRotation(wayPoints[index].transform.position - transform.position);
    }
    public void SetPoints(Transform transform)
    {
        Vector3 destination = wayPoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= .05)
        {
            if (index < wayPoints.Count - 1)
            {
                index++;
            }
        }
    }
    private void SetRandomSpeed()
    {
        int randomSpeed = Random.Range(5, 8);
        _speed = randomSpeed;
    }
    private void SetRandomDestination()
    {
        int randomDes = Random.Range(1, 3);
        if(randomDes == 1)
        {
            wayPoints = Way.RouteOne;
        }
        else
        {
            wayPoints = Way.RouteTwo;
        }
    }
    public void SetPoint(Transform pointParent)
    {
        var _points = new Transform[pointParent.childCount];
    }
}
