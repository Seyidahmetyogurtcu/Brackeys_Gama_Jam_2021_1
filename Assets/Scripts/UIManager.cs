using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace AlphaGame { 
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;
        [SerializeField]private GameObject gameOverPanel, levelSelectPanel, mainMenuPanel, optionsPanel, creditsPanel;
        [SerializeField]private Text distanceText;
        public Text DistanceText { get { return distanceText; } }
        AudioSource audio;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void PlayButton()
        {
            
            mainMenuPanel.SetActive(false);
            levelSelectPanel.SetActive(true);
        }
        public void LevelSelectButton(int level)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
        }
       
        public void OptionsButton()
        {
            mainMenuPanel.SetActive(false);
            optionsPanel.SetActive(true);
        }
        public void CreditsButton()
        {
            mainMenuPanel.SetActive(false);
            creditsPanel.SetActive(true);
        }

        public void RetryButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void GameOverButton()
        {
            gameOverPanel.SetActive(true);
        }
        public void ExitButton()
        {

#if UNITY_STANDALONE
            Application.Quit();
#endif

#if UNITY_EDITOR  
            UnityEditor.EditorApplication.isPlaying = false;
#endif   
        }
    }
}