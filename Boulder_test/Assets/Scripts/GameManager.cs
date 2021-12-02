using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
    public class GameManager : MonoBehaviour {

        private static int playerScore;

        public static string playerName;

        // Start is called before the first frame update
        void Start() {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
        }

        public void AddScore(int amount) {
            playerScore += amount;
        }

        public bool SubmitScore() {
            Score scores = new Score(GameConfig.GetHighScorePath());
            if (scores.Add(playerName, playerScore)) {
                scores.Save();
                return true;
            }

            return false;
        }

        public void SetName(string name) {
            playerName = name;
            Debug.Log(playerName);
            SceneManager.LoadScene("Menu");
        }

        public void SetEffectVolume(float volume) {
            PlayerPrefs.SetFloat("EffectVolume", volume);
        }
    }
}
