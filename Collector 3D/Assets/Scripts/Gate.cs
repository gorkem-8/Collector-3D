using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform leftGate;
    [SerializeField] private Transform rightGate;
    private bool open = false;
    private float rotateSpeed = 3f;

    void Update()
    {
        if (!open) return;

        leftGate.rotation = Quaternion.RotateTowards(leftGate.rotation, Quaternion.Euler(0, 0, 50f), rotateSpeed);
        rightGate.rotation = Quaternion.RotateTowards(rightGate.rotation, Quaternion.Euler(0, 0, -50f), rotateSpeed);
        if (Mathf.Abs(leftGate.rotation.eulerAngles.z - 50f) < 1f)
        {
            open = false;
            player.MovementStop(false);
        }
    }

    public void OpenGates()
    {
        open = true;
    }
}
