using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Camera cam;
    private Vector3 oldTouchPosition;
    private float speed = 8f;
    private bool stopped;
    private Stack<Transform> ballStack;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        oldTouchPosition = Vector3.zero;
        ballStack = new Stack<Transform>();
    }

    void Update()
    {
        if (stopped) return;

        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 screenPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = cam.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 15f));
            if (oldTouchPosition != Vector3.zero)
            {
                if (worldPosition.x - oldTouchPosition.x > 0.01f)
                {
                    MoveSides(true);
                }

                else if (worldPosition.x - oldTouchPosition.x < -0.01f)
                {
                    MoveSides(false);
                }

                else
                    MoveForward();
            }
            oldTouchPosition = worldPosition;
        }
        else
            MoveForward();

        if (Touchscreen.current.primaryTouch.press.wasReleasedThisFrame)
            oldTouchPosition = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Balls _))
        {
            ballStack.Push(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Balls _))
        {
        }
    }

    void MoveForward()
    {
        rb.velocity = Vector3.forward * speed;
    }

    void MoveSides(bool right)
    {
        rb.velocity = right ? new Vector3(1f, 0f, 1f) * speed :  new Vector3(-1f, 0f, 1f) * speed;
    }

    public void MovementStop(bool stopped)
    {
        this.stopped = stopped;
        if (stopped) rb.velocity = Vector3.zero;
    }

}
