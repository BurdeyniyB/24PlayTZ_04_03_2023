using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseObstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] Obstacles;
    int range;

    void Start()
    {
        range = Random.Range(0, Obstacles.Length);

        Obstacles[range].SetActive(true);
    }
}
