using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

	void Awake () {
        if (instance == null)
            instance = this;
	}

	[SerializeField] private GameObject HoldText;
	[SerializeField] private GameObject WarpEffect;
	[SerializeField] private GameObject EndPanel;

    public void StartGame()
    {
       HoldText.SetActive(false);
       WarpEffect.SetActive(true);
    }

    public void EndGame()
    {
      EndPanel.SetActive(true);
    }
}
