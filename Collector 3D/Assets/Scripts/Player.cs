using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    private Rigidbody rb;
    private Camera cam;
    private Vector3 oldTouchPosition;
    private float speed = 8f;
    private bool stopped = false;
    private List<Transform> objectList;
    private bool firstTouch = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        oldTouchPosition = Vector3.zero;
        objectList = new List<Transform>();
    }

    private void Start()
    {
    }

    void Update()
    {
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
            objectList.Add(other.transform);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Balls _))
        {
            objectList.Remove(other.transform);
        }
    }

    void MoveForward()
    {
        if (!firstTouch) return;
        rb.velocity = stopped ? Vector3.zero : Vector3.forward * speed;
    }

    void MoveSides(bool right)
    {
        float a = stopped ? 0f : 1f;
        rb.velocity = right ? new Vector3(1.5f, 0f, a) * speed :  new Vector3(-1.5f, 0f, a) * speed;
    }

    public void MovementStop(bool stopped)
    {
        this.stopped = stopped;
    }

    public void PushBalls()
    {
        foreach (Transform i in objectList.ToArray())
        {
            if (i != null)
            {
                i.GetComponent<Balls>().MoveBalls();
            }
        }
    }

    public void GameStart()
    {
        firstTouch = true;
        startButton.SetActive(false);
    }

}
