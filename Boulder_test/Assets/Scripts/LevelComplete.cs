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

        [SerializeField]
        LevelLoader loader;
        // Start is called before the first frame update
        void Start() {
            gemsText.text = "Gem Score: " + LevelController.levelScore;
            timeText.text = "Time Score: " + (int)LevelController.timeLeft;
            totalText.text = "Total Score: " + (LevelController.levelScore + (int)LevelController.timeLeft);
            gm.AddScore((LevelController.levelScore + (int)LevelController.timeLeft));
        }

        public void Continue() {
            StartCoroutine(loader.LoadLevel(LevelController.nextLevel));
        }

        public void QuitGame() {
            StartCoroutine(loader.LoadLevel("Menu"));
        }

    }
}