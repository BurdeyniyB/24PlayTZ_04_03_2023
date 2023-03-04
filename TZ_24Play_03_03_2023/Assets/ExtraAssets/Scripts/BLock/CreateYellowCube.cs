using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateYellowCube : MonoBehaviour
{
    [SerializeField] private GameObject YellowCube;
    [SerializeField] private GameObject newBlock;
    public bool createC = true;
    int range;

    public void CreateCube()
    {
     if(createC)
     {
        Vector3 spawnPos = transform.position + new Vector3(Random.Range(-1f, 1f), 0.5f, 2.5f);
        newBlock = Instantiate(YellowCube, spawnPos, Quaternion.identity);
        newBlock.transform.SetParent(transform);
     }
    }
}
