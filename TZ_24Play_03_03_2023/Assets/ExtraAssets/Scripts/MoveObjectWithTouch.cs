// Importing necessary libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A script to move an object using touch input
public class MoveObjectWithTouch : MonoBehaviour
{
// A static instance of this script to be used in other scripts
public static MoveObjectWithTouch instance;

// Awake method is called when the script instance is being loaded
void Awake () {
    // If there is no instance of this script, make this script the instance
    if (instance == null)
        instance = this;
}

// Serialized fields are private fields that can be viewed and edited in the Unity Inspector
[SerializeField] private GameObject Player; // A reference to the object that will be moved
[SerializeField] private Transform PosRight; // A reference to the right boundary of the movement area
[SerializeField] private Transform PosLeft; // A reference to the left boundary of the movement area

public float Lerp; // The speed at which the object moves
public float speed; // The speed at which Lerp increases
private float PosX; // The current x position of the object

bool end; // A flag to indicate whether the game has ended

// Update is called once per frame
void Update() {

    // Increase Lerp based on time and speed
    Lerp += Time.deltaTime * speed;

    // If there is touch input and it's being moved, and the game hasn't ended
    if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !end)
    {
        // If the new x position is within the movement area boundaries
        if((PosX + Input.GetTouch(0).deltaPosition.x /100) < PosRight.transform.position.x && (PosX + Input.GetTouch(0).deltaPosition.x /100) > PosLeft.transform.position.x)
        {
            // Start the game if it hasn't already started
            GameManager.instance.StartGame();

            // Update the current x position
            PosX = PosX + Input.GetTouch(0).deltaPosition.x /100;
        }

        // Move the object towards the new position using Lerp
        Player.transform.position = Vector3.Lerp( Player.transform.position, new Vector3(PosX, 0, 0), Lerp);
    }
}

// A method to end the game
public void EndGame()
{
    end = true;
}
}