using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddYellowBlock : MonoBehaviour
{
    public static AddYellowBlock instance;

	void Awake () {
        if (instance == null)
            instance = this;
	}

	[SerializeField] private GameObject YellowCube;
    [SerializeField] private GameObject newBlock;
    [SerializeField] private Transform childtransform;

    void Update()
    {
         foreach (Transform child in transform)
         {
             child.position = new Vector3(childtransform.position.x, child.position.y, childtransform.position.z);
         }
    }

    public void Added()
    {
         foreach (Transform child in transform)
         {
             child.position += new Vector3(0, 1f, 0);
         }

         newBlock = Instantiate(YellowCube, new Vector3(transform.position.x, 0.5f, 0), Quaternion.identity);
         newBlock.transform.SetParent(transform);
    }
}
