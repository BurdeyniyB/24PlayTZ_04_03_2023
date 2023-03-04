using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBlock : MonoBehaviour
{
    [SerializeField] private GameObject animatorPrefab;
    private GameObject animator;

    void Start()
    {
      animator = Instantiate(animatorPrefab, new Vector3(Random.Range(2.5f, 5f), Random.Range(2.5f, 7f), 0), Quaternion.identity);
      animator.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.CompareTag("Yellow"))
        {
            Destroy(other.gameObject);
            AddYellowBlock.instance.Added();


//            animator.transform.position = new Vector3(Random.Range(2.5f, 3f), Random.Range(2.5f, 3f), 0);
            if(animator == null)
            {
              animator = Instantiate(animatorPrefab, new Vector3(Random.Range(2.5f, 4f), Random.Range(2.5f, 4f), 0), Quaternion.identity);
            }
            animator.SetActive(true);
            Invoke("DeleteAnim", 1f);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Red")
        {
          CameraFollow.instance.shaker = false;
          CameraShaker.Invoke();
          this.gameObject.transform.SetParent(GameObject.Find("CubeWall").transform);
        }
    }

    void DeleteAnim()
    {
       Destroy(animator);
    }
}
