using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    [SerializeField] private Gate gate;
    [SerializeField] private Material groundMat;
    private float realTime;
    private bool moveUp = false;
    private Transform ground;
    private bool finished = false;

    private void Awake()
    {
        ground = transform.parent;
    }

    private void Update()
    {
        if (finished) return;
        if (!moveUp) return;

        if (ground.position.y < -0.5f)
        {
            ground.Translate(Vector3.up * 2f * Time.deltaTime);
        }
        else
        {
            finished = true;
            gate.OpenGates();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (finished) return;
        if (other.TryGetComponent(out Player player))
        {
            player.MovementStop(true);
            player.PushBalls();
        }
        if (other.TryGetComponent(out Balls _))
        {
            realTime = 0f;
            Destroy(other.gameObject,2f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (moveUp) return;
        if (other.TryGetComponent(out Player _))
        {
            realTime += Time.deltaTime;
            if (realTime < 2f) return;
            realTime = 0f;

            gameObject.transform.parent.GetComponent<MeshRenderer>().material = groundMat;
            moveUp = true;
        }
    }
}
