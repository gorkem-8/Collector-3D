using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.TryGetComponent(out Player player))
        {
            Debug.Log("player");
            player.MovementStop(true);
        }
    }

}
