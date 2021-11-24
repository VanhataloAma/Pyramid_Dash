using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GA.Pyramid_dash;
using TMPro;
using UnityEngine.SceneManagement;

namespace GA.Pyramid_dash {
    public class LevelComplete : MonoBehaviour {
        [SerializeField]
        TMP_Text gemsText;

        [SerializeField]
        TMP_Text timeText;

        [SerializeField]
        TMP_Text totalText;

        [SerializeField]
        GameManager gm;
        // Start is called before the first frame update
        void Start() {
            gemsText.text = "Gems: " + LevelController.levelScore;
            timeText.text = "Time: " + (int)LevelController.timeLeft;
            totalText.text = "Total Score: " + (LevelController.levelScore + (int)LevelController.timeLeft);
            gm.AddScore((LevelController.levelScore + (int)LevelController.timeLeft));
        }

        public void Continue() {
            SceneManager.LoadScene(LevelController.nextLevel);
        }

        public void QuitGame() {
            SceneManager.LoadScene("Menu");
        }

    }
}