using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.Pyramid_dash {
    public class GameManager : MonoBehaviour {

        private float fixedDeltaTime;

        private bool paused;

        // Start is called before the first frame update
        void Awake() {
            Time.timeScale = 1f;
            this.fixedDeltaTime = Time.fixedDeltaTime;
            paused = false;
            Debug.Log(SceneManager.GetActiveScene().rootCount);
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                TogglePause();
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
    }
}