using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnding : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelPanel;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.MovementStop(true);
            nextLevelPanel.SetActive(true);
        }
    }


}
