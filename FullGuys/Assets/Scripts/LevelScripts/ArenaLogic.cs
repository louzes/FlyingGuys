using UnityEngine;

public class ArenaLogic : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] private GameObject TriggerWall;

    [Header("Teleport")]
    [SerializeField] private Vector3 _teleportTo;
    [SerializeField] private Transform _tpDestination;
    [SerializeField] private float _tpPointRadius;
    [SerializeField] private float timerDuration = 3f;

    [Header("Hitting Box")]
    [SerializeField]private Transform chargePoint;
    [SerializeField]private Transform hitPoint;
    [SerializeField]private float normalSpeed = 5f;
    [SerializeField]private float chargingSpeed = 10f;

    private Transform targetPoint;
    private float currentSpeed;

    private void Start()
    {
        targetPoint = chargePoint;
        currentSpeed = normalSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (TriggerWall != null)
        {
            Destroy(TriggerWall);
            print("Wall is down");
        }
            
        if (gameObject.layer == 7) //water
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
                print(other.transform.parent + "is destroyed");
                return; 
            }
            Destroy(other);
        }
            
        if (gameObject.layer == 8 && _tpDestination != null) //teleport
        {
            other.transform.parent.position = _tpDestination.transform.position;
            print("Teleport!");
        }
            
    }
    private void Update()
    {

        if (gameObject.layer == 10) //obstacles
        {
            if (chargePoint != null && hitPoint != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, currentSpeed * Time.deltaTime);

                if (transform.position == targetPoint.position)
                {
                    if (targetPoint == chargePoint)
                    {
                        targetPoint = hitPoint;
                        currentSpeed = normalSpeed;
                    }
                    else if (targetPoint == hitPoint)
                    {
                        targetPoint = chargePoint;
                        currentSpeed = chargingSpeed;
                    }
                }
            }          
        }      
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_teleportTo, _tpPointRadius);
    }
}
