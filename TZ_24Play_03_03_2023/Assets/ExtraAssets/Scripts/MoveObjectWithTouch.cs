using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectWithTouch : MonoBehaviour
{
    public static MoveObjectWithTouch instance;

	void Awake () {
        if (instance == null)
            instance = this;
	}

      [SerializeField] private GameObject Player;
      [SerializeField] private Transform PosRight;
      [SerializeField] private Transform PosLeft;

   public float Lerp;
   public float speed;
   private float PosX;

   bool end;

 void Update() {

        Lerp += Time.deltaTime * speed;
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !end)
        {
          if((PosX + Input.GetTouch(0).deltaPosition.x /100) < PosRight.transform.position.x && (PosX + Input.GetTouch(0).deltaPosition.x /100) > PosLeft.transform.position.x)
          {
            GameManager.instance.StartGame();
            PosX = PosX + Input.GetTouch(0).deltaPosition.x /100;
          }

          Player.transform.position = Vector3.Lerp( Player.transform.position, new Vector3(PosX, 0, 0), Lerp);
        }
       }

     public void EndGame()
    {
      end = true;
    }
}
