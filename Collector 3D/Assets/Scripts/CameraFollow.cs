using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float positionZDifference;

    void Awake()
    {
        positionZDifference = transform.position.z - player.position.z;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, positionZDifference + player.position.z);
    }
}
