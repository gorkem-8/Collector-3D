using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnding : MonoBehaviour
{
    [SerializeField] private Manager manager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.MovementStop(true);
            manager.NextLevel();
        }
    }


}
