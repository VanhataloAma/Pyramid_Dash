using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
    public class GameManager : MonoBehaviour {

        private float fixedDeltaTime;

        private bool paused;

        private static int playerScore;

        public int levelScore;

        public static string playerName;

        [SerializeField]
        bool inMenu = false;

        // Start is called before the first frame update
        void Start() {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
            this.fixedDeltaTime = Time.fixedDeltaTime;
            paused = false;
        }

        // Update is called once per frame
        void Update() {
            if (!inMenu) {
                if (Input.GetKeyDown(KeyCode.Escape)) {
                    TogglePause();
                }
            }
            
        }

        void TogglePause() {
            if (!paused) {
                var SceneLoad = SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
                SceneLoad.completed += (s) => {
                    Debug.Log("Done");
                    Debug.Log(SceneManager.GetSceneAt(0).name);
                    SceneManager.GetSceneByName("PauseMenu").GetRootGameObjects()[0].gameObject.transform.position = GameObject.Find("Main Camera").transform.position;
                };
                paused = true;
                Time.timeScale = 0f;

            } else {
                SceneManager.UnloadSceneAsync("PauseMenu");
                paused = false;
                Time.timeScale = 1f;
            }
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        }

        public void AddScore() {
            levelScore++;
        }

        public bool SubmitScore() {
            Score scores = new Score(GameConfig.GetHighScorePath());
            if (scores.Add(playerName, levelScore)) {
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
    }
}
