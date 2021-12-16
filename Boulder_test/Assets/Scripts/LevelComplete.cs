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

        int gemsScore = 0;
        int timeScore = 0;
        int totalScore = 0;

        bool ready = false;

        AudioSource audi;

        // Start is called before the first frame update
        void Start() {
            audi = GetComponent<AudioSource>();
            audi.volume = PlayerPrefs.GetFloat("EffectVolume");
            gm.AddScore((LevelController.levelScore + (int)LevelController.timeLeft));
            StartCoroutine(StartDelay());
        }

        void Update() {
            if (ready) {
                if (Input.GetMouseButtonDown(0)) {
                    gemsScore = LevelController.levelScore;
                    timeScore = (int)LevelController.timeLeft;
                    totalScore = (LevelController.levelScore + (int)LevelController.timeLeft);
                }
            }
        }
        void FixedUpdate() {
            if (ready) {
                if (gemsScore < LevelController.levelScore) {
                    gemsScore++;

                } else if (timeScore < (int)LevelController.timeLeft) {
                    timeScore++;

                } else if (totalScore < (LevelController.levelScore + (int)LevelController.timeLeft)) {
                    totalScore++;
                } else {
                    audi.Stop();
                }

                gemsText.text = "Gem Score: " + gemsScore;
                timeText.text = "Time Score: " + timeScore;
                totalText.text = "Total Score: " + totalScore;
            }
            
        }
        void CountScore() {
            for (int i = 0; i < LevelController.levelScore; i++) {

            }
        }
        public void Continue() {
            StartCoroutine(loader.LoadLevel(LevelController.nextLevel, 1f));
        }

        public void QuitGame() {
            StartCoroutine(loader.LoadLevel("Menu", 1f));
        }

        public IEnumerator StartDelay() {
            yield return new WaitForSeconds(1.1f);

            ready = true;
            audi.Play();
        }

    }
}