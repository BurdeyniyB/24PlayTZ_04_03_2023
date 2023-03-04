using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public static BlockSpawner instance;

	void Awake () {
        if (instance == null)
            instance = this;
	}

    public GameObject YellowblockPrefab;
    public GameObject RedblockPrefab;
    public float blockSpeed = 10f;
    public float spawnRate = 2f;
    public float blockWidth = 1f;
    public float blockDepth = 1f;

    private float spawnTimer;
    private bool start;
    private int redBlock = 1;

    private float PosZForSpawnDlockStart;

    void Start()
    {
       SpawnBlockStart();
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(start)
        {
         if (spawnTimer <= 0)
         {
             redBlock++;
             SpawnBlock();
             spawnTimer = spawnRate;
         }

         foreach (Transform child in transform)
         {
             child.position += Vector3.back * blockSpeed * Time.deltaTime;
         }
        }

        if (transform.childCount > 0)
        {
            Transform firstBlock = transform.GetChild(0);
            if (firstBlock.position.z < -blockDepth)
            {
                Destroy(firstBlock.gameObject);
            }
        }
    }

    // создаем новый блок
    private void SpawnBlock()
    {
        Vector3 spawnPos = transform.position + Vector3.right;
        if(redBlock != 4)
        {
           GameObject newBlock = Instantiate(YellowblockPrefab, spawnPos, Quaternion.identity, transform);
           newBlock.GetComponent<CreateYellowCube>().CreateCube();
        }
        else
        {
           GameObject newBlock = Instantiate(RedblockPrefab, spawnPos, Quaternion.identity, transform);
           redBlock = 0;
        }
    }

    private void SpawnBlockStart()
    {
      for(int i = 1; i < 10; i++)
      {
        PosZForSpawnDlockStart = i * -5f;

        Vector3 spawnPos = transform.position + Vector3.right + new Vector3(0, 0, PosZForSpawnDlockStart);

        if(i != 1)
        {
           GameObject newBlock = Instantiate(YellowblockPrefab, spawnPos, Quaternion.identity, transform);

          if(i > 5)
          {
          newBlock.GetComponent<CreateYellowCube>().createC = false;
          }
          newBlock.GetComponent<CreateYellowCube>().CreateCube();
        }
        else
        {
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