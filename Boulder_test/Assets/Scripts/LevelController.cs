using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
    public class LevelController : MonoBehaviour {
        
        private float fixedDeltaTime;

        public int requiredGems = 10;

        public int gemValue = 10;

        public int timeLimit = 150;

        public int sandColor = 0;

        public static int levelScore;

        public static int current_Level_Index;

        public static float timeLeft;

        public static string nextLevel = "Level 0";

        int gemsCollected;

        private bool paused;

        [SerializeField]
        UIController ui;

        [SerializeField]
        PortalController portal;

        AudioSource audi;

        public AudioClip ticktock_Sfx;

        public AudioClip button_Sfx;

        float soundTimer;

        void Start() {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
            this.fixedDeltaTime = Time.fixedDeltaTime;
            paused = false;
            ui.SetGems(gemsCollected, requiredGems);
            timeLeft = timeLimit;
            levelScore = 0;
            current_Level_Index = SceneManager.GetActiveScene().buildIndex;
            nextLevel = portal.next_Level;
            Debug.Log(nextLevel);
            audi = GetComponent<AudioSource>();
            audi.volume = PlayerPrefs.GetFloat("EffectVolume");
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                TogglePause();
            }

            if (gemsCollected >= requiredGems && !portal.IsActive()) {
                portal.Activate();
            }
        }

        void FixedUpdate() {
            soundTimer += Time.fixedDeltaTime;
            timeLeft -= Time.fixedDeltaTime;
            ui.SetTimer((int)timeLeft);
            if (timeLeft <= 10 && soundTimer >= 1 && timeLeft >= 0) {
                audi.PlayOneShot(ticktock_Sfx);
                soundTimer = 0f;
            }
            if (timeLeft <= 0) {
                GameObject.Find("character").GetComponent<CharController>().GameOver();
                timeLeft = 10;
            }
        }

        public void TogglePause() {
            audi.PlayOneShot(button_Sfx);
            if (!paused) {
                var SceneLoad = SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
                SceneLoad.completed += (s) => {
                    /*Debug.Log("Done");
                    Debug.Log(SceneManager.GetSceneAt(0).name);*/
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
            gemsCollected++;
            levelScore += gemValue;
            ui.SetScore(levelScore);
            ui.SetGems(gemsCollected, requiredGems);
        }

        public bool isPaused() {
            return paused;
        }
    }
}