using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
    public class PauseController : MonoBehaviour {

        AudioSource audi;

        public AudioClip button_Sfx;

        void Start() {
            audi = GetComponent<AudioSource>();
            audi.volume = PlayerPrefs.GetFloat("EffectVolume");
        }

        public void QuitToMenu() {
            audi.PlayOneShot(button_Sfx);
            SceneManager.LoadScene("Menu");
        }

        public void RestartLevel() {
            audi.PlayOneShot(button_Sfx);
            SceneManager.LoadSceneAsync(SceneManager.GetSceneAt(0).name);
        }

        public void Resume() {
            audi.PlayOneShot(button_Sfx);
            GameObject.Find("LevelController").gameObject.GetComponent<LevelController>().TogglePause();
        }
    }

}
