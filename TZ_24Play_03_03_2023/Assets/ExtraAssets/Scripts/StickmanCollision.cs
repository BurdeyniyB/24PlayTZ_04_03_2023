using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("StickmanCollisionOnTriggerEnter");
        if (other.CompareTag("Obstacle"))
        {
            GameManager.instance.EndGame();
        }
    }
}
