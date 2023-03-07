// Importing necessary namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Defining the UIManager class, which inherits from the MonoBehaviour class
public class UIManager : MonoBehaviour
{
// Defining a static instance variable of the UIManager class
public static UIManager instance;

// Awake function is called when the script instance is being loaded
void Awake () {
    // If instance is null, assign it to the current UIManager instance
    if (instance == null)
        instance = this;
}

// Declaring private GameObject variables for HoldText, WarpEffect, and EndPanel
[SerializeField] private GameObject HoldText;
[SerializeField] private GameObject WarpEffect;
[SerializeField] private GameObject EndPanel;

// Declaring a public function StartGame()
public void StartGame()
{
    // Setting HoldText to inactive and WarpEffect to active
    HoldText.SetActive(false);
    WarpEffect.SetActive(true);
    // Calling the GameState function with the argument "Game start"
    GameState("Game start");
}

// Declaring a public function EndGame()
public void EndGame()
{
    // Setting EndPanel to active
    EndPanel.SetActive(true);
    // Calling the GameState function with the argument "Game over"
    GameState("Game over");
}

// Declaring a private function GameState() with a string parameter state
void GameState(string state)
{
    // Outputting the state parameter using Debug.Log
    Debug.Log(state);
}
}