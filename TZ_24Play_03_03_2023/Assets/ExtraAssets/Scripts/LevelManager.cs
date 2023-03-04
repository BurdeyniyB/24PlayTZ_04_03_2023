using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    public class LevelManager : MonoBehaviour
    {
        private Button PlayButton;

        void Start()
        {
            PlayButton = GetComponent<Button>();
            PlayButton.onClick.AddListener (Task);
        }

        public void Task()
        {
            SceneManager.LoadScene(0);
        }

    }
