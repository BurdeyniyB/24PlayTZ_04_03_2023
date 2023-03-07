// Importing necessary libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Defining the BlockSpawner class
public class BlockSpawner : MonoBehaviour
{
// Creating a static instance of BlockSpawner
public static BlockSpawner instance;

// Setting up the Awake method
void Awake ()
{
    // If no instance exists, set the current instance as the instance
    if (instance == null)
        instance = this;
}

// Defining public variables
public GameObject YellowblockPrefab;
public GameObject RedblockPrefab;
public float blockSpeed = 10f;
public float spawnRate = 2f;
public float blockWidth = 1f;
public float blockDepth = 1f;

// Defining private variables
private float spawnTimer;
private bool start;
private int redBlock = 1;
private float PosZForSpawnDlockStart;

// Setting up the Start method
void Start()
{
    // Calling the SpawnBlockStart method to begin spawning blocks
    SpawnBlockStart();
}

// Setting up the Update method
private void Update()
{
    // Decreasing the spawn timer
    spawnTimer -= Time.deltaTime;

    // Checking if the game has started
    if(start)
    {
        // Spawning a new block if the spawn timer has reached zero
        if (spawnTimer <= 0)
        {
            redBlock++;
            SpawnBlock();
            spawnTimer = spawnRate;
        }

        // Moving each block backwards with time
        // foreach is a loop statement in the C# programming language that allows you to iterate over the elements in a collection or array.
        foreach (Transform child in transform)
        {
            child.position += Vector3.back * blockSpeed * Time.deltaTime;
        }
    }

    // Destroying blocks that have moved past the screen
    if (transform.childCount > 0)
    {
        Transform firstBlock = transform.GetChild(0);
        if (firstBlock.position.z < -blockDepth)
        {
            Destroy(firstBlock.gameObject);
        }
    }
}

// Defining the SpawnBlock method
private void SpawnBlock()
{
    // Setting up the spawn position for the new block
    Vector3 spawnPos = transform.position + Vector3.right;

    // Checking if a red block should be spawned
    if(redBlock != 4)
    {
        // Spawning a yellow block
        GameObject newBlock = Instantiate(YellowblockPrefab, spawnPos, Quaternion.identity, transform);
        newBlock.GetComponent<CreateYellowCube>().CreateCube();
    }
    else
    {
        // Spawning a red block
        GameObject newBlock = Instantiate(RedblockPrefab, spawnPos, Quaternion.identity, transform);
        redBlock = 0;
    }
}

// Defining the SpawnBlockStart method
private void SpawnBlockStart()
{
    // Looping through to spawn the starting blocks
    for(int i = 1; i < 10; i++)
    {
        // Setting up the spawn position for the new block
        PosZForSpawnDlockStart = i * -5f;
        Vector3 spawnPos = transform.position + Vector3.right + new Vector3(0, 0, PosZForSpawnDlockStart);

        // Checking if a yellow or red block should be spawned
        if(i != 1)
        {
            // Spawning a yellow block
            GameObject newBlock = Instantiate(YellowblockPrefab, spawnPos, Quaternion.identity, transform);

            // Checking if the block should not create cubes
            if(i > 5)
            {
                newBlock.GetComponent<CreateYellowCube>().createC = false;
            }
            newBlock.GetComponent<CreateYellowCube>().CreateCube();
        }
        else
        {
           // Spawning a red block
           GameObject newBlock = Instantiate(RedblockPrefab, spawnPos, Quaternion.identity, transform);
           redBlock = 0;
        }

      }
    }

    public void StartGame()
    {
       start = true;
    }

    public void EndGame()
    {
      start = false;
    }
}