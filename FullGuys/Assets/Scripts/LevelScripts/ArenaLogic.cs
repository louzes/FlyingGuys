using UnityEngine;

public class ArenaLogic : MonoBehaviour
{
    [SerializeField] private Vector3 _teleportTo;
    [SerializeField] private float _tpPointRadius;
    [SerializeField] private GameObject TriggerWall;
    private void OnCollisionEnter(Collision collision)
    {
        print("ok");
        if (gameObject.layer == 7) //water
        {
            Destroy(collision.gameObject);
        }

        if (gameObject.layer == 8) //teleport
        {
            print("sus");
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("AI"))
            {
                collision.gameObject.transform.position = new Vector3(_teleportTo.x, _teleportTo.y, _teleportTo.z);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (TriggerWall != null) Destroy(TriggerWall);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_teleportTo, _tpPointRadius);
    }
}
