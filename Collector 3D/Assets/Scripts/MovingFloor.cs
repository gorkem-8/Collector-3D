using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovingFloor : MonoBehaviour
{
    [SerializeField] private GameObject failPanel;
    [SerializeField] private Gate gate;
    [SerializeField] private Material groundMat;
    [SerializeField] private TextMeshPro ballText;
    [SerializeField] private int neededBall;
    private int currentBall = 0;

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
            ground.position = new Vector3(ground.position.x, -0.5f, ground.position.z);
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
            Destroy(other.gameObject,3f);
            currentBall++;
            ballText.text = currentBall + "/" + neededBall;
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

            if (currentBall >= neededBall)
            {
                gameObject.transform.parent.GetComponent<MeshRenderer>().material = groundMat;
                ballText.gameObject.SetActive(false);
                moveUp = true;
            }
            else
                failPanel.SetActive(true);


        }
    }
}
