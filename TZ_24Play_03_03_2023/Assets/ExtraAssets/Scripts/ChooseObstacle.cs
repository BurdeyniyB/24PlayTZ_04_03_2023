// Import necessary libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define class ChooseObstacle, which inherits from MonoBehaviour
public class ChooseObstacle : MonoBehaviour
{
    // Serialize field Obstacles, which is an array of GameObjects
    [SerializeField] private GameObject[] Obstacles;

    // Declare variable range, which will be used to store a random integer
    int range;

    // Start is called before the first frame update
    void Start()
    {
     // Set range to a random integer between 0 (inclusive) and the length of Obstacles (exclusive)
     range = Random.Range(0, Obstacles.Length);

     // Activate the obstacle at index range in the Obstacles array
     Obstacles[range].SetActive(true);
    }
}






