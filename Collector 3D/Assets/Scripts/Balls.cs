using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 25f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MoveBalls()
    {
        rb.velocity = Vector3.forward * speed;
    }

}
