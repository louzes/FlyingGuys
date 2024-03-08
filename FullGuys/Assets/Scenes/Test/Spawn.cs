using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject player;
    public Transform place;
    void Start()
    {
        Instantiate(player, place.position, Quaternion.Euler(transform.rotation.x, 180f, transform.rotation.z));
    }

    
}
