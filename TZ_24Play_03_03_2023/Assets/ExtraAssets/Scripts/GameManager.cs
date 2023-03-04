using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;


	void Awake () {
        if (instance == null)
            instance = this;
	}

	bool start;
	bool end;

    public void StartGame()
    {
       if(!start)
       {
         start = true;
         BlockSpawner.instance.StartGame();
         UIManager.instance.StartGame();
       }
    }

    public void EndGame()
    {
       if(!end)
       {
         end = true;
         CameraShaker.Invoke();
         BlockSpawner.instance.EndGame();
         UIManager.instance.EndGame();
         MoveObjectWithTouch.instance.EndGame();
       }
    }
}