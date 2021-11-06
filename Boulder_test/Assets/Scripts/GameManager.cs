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
            this.fixedDeltaTime = Time.fixedDeltaTime;
            paused = false;
            Debug.Log(SceneManager.GetActiveScene().rootCount);
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (!paused) {
                    var SceneLoad = SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
                    SceneLoad.completed += (s) => {
                        Debug.Log("Done");
                        Debug.Log(SceneManager.GetSceneByName("PauseMenu").rootCount);
                        SceneManager.GetSceneByName("PauseMenu").GetRootGameObjects()[0].gameObject.transform.position = GameObject.Find("Main Camera").transform.position;
                    };

                    paused = true;
                    Time.timeScale = 0f;
                } else {
                    SceneManager.UnloadSceneAsync("PauseMenu");
                    paused = false;
                    Time.timeScale = 1f;
                }
                
                /*if (!paused) {
                    Time.timeScale = 0f;
                    paused = true;
                } else {
                    Time.timeScale = 1f;
                    paused = false;
                }

                Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;*/
            }
        }
    }
}
