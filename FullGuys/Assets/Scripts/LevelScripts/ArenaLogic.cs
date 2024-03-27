using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
    [SerializeField] private Transform chargePoint;
    [SerializeField] private Transform hitPoint;
    [SerializeField] private float normalSpeed = 5f;
    [SerializeField] private float chargingSpeed = 10f;

    private Transform targetPoint;
    private float currentSpeed;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
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
            if (other != null)
            {
                if(other.transform.tag.Equals("Player"))
                {
                    StartCoroutine(Delay());
                }
                Destroy(other.transform.gameObject);
            }
        }

        if (gameObject.layer == 8 && _tpDestination != null) //teleport
        {
            _audioManager.PlaySFX(_audioManager.Teleport);
            other.transform.position = _tpDestination.transform.position;
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
    IEnumerator Delay()
    {
        _audioManager.StopMusic(true);
        _audioManager.PlaySFX(_audioManager.Bloop);
        yield return new WaitForSeconds(.5f);
        _audioManager.PlaySFX(_audioManager.PlayerDeath);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_teleportTo, _tpPointRadius);
    }
}
