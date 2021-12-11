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

        [SerializeField]
        LevelLoader loader;

        AudioSource audi;
        void Start() {
            audi = GetComponent<AudioSource>();
            audi.volume = PlayerPrefs.GetFloat("EffectVolume");
            if (LevelController.timeLeft <= 0) {
                timeText.gameObject.SetActive(true);
            }
        }
        public void RestartLevel() {
            StartCoroutine(loader.LoadLevel(LevelController.current_Level_Index, 1f));
            //SceneManager.LoadScene(LevelController.current_Level_Index);
        }

        public void QuitGame() {
            StartCoroutine(loader.LoadLevel("Menu", 1f));
            //SceneManager.LoadScene("Menu");
        }

    }
}