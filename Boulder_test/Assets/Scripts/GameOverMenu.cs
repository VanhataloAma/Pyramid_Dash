using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GA.Pyramid_dash;
using TMPro;

namespace GA.Pyramid_dash {
    public class GameOverMenu : MonoBehaviour {

        [SerializeField]
        private TMP_Text timeText;

        void Start() {
            if (LevelController.timeLeft <= 0) {
                timeText.gameObject.SetActive(true);
            }
        }
        public void RestartLevel() {
            SceneManager.LoadScene(LevelController.current_Level_Index);
        }

        public void QuitGame() {
            SceneManager.LoadScene("Menu");
        }

    }
}