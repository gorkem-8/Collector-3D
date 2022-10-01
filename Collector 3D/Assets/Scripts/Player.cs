using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    void Update()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 screenPosition= Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = new Vector3(screenPosition.x,screenPosition.y,15f);
            Vector3 world = cam.ScreenToWorldPoint(worldPosition);
            Debug.Log(world);
        }    
    }

    void FixedUpdate()
    {
        rb.velocity = Vector3.forward * 5f;
        
    }
}
