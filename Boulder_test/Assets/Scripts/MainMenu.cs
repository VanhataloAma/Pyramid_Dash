using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
    public class MainMenu : MonoBehaviour {
        [SerializeField]
        GameManager gm;

        [SerializeField]
        Slider effectSlider;

        [SerializeField]
        Slider musicSlider;

        [SerializeField]
        Toggle diggingSfx;

        [SerializeField]
        LevelLoader loader;

        AudioSource audi;

        public AudioClip button_Sfx;

        void Start() {
            Time.timeScale = 1f;
            audi = GetComponent<AudioSource>();
            audi.volume = PlayerPrefs.GetFloat("EffectVolume");
            if (PlayerPrefs.HasKey("EffectVolume")) {
                effectSlider.value = PlayerPrefs.GetFloat("EffectVolume");
            } else {
                effectSlider.value = 0.5f;
            }

            if (PlayerPrefs.HasKey("MusicVolume")) {
                effectSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            } else {
                musicSlider.value = 0.5f;
            }
            
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }

        public void PlayGame ()
        {
            SceneManager.LoadScene("Level 1");
        }

        public void QuitGame ()
        {
            gm.SubmitScore();
            Debug.Log("This won't happen inside unity editor, but we did indeed, rage quit");
            Application.Quit();
        }

        public void LevelSelect(string level_Name) {
            audi.PlayOneShot(button_Sfx);
            StartCoroutine(loader.LoadLevel(level_Name, 1f));
            //SceneManager.LoadScene(level_Name);
        }

        public void ChangeEffectVolume() {
            gm.SetEffectVolume(effectSlider.value);
        }

        public void ChangeMusicVolume() {
            gm.SetMusicVolume(musicSlider.value);
        }

        public void ChangeDiggingSfx() {
            gm.SetDiggingSfx(diggingSfx.isOn);
        }

    }
}