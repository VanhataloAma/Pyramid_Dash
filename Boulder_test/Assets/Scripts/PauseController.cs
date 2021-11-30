using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
    public class PauseController : MonoBehaviour {

        public void QuitToMenu() {
            SceneManager.LoadScene("Menu");
        }

        public void RestartLevel() {
            SceneManager.LoadSceneAsync(SceneManager.GetSceneAt(0).name);
        }

        public void Resume() {
            GameObject.Find("LevelController").gameObject.GetComponent<LevelController>().TogglePause();
        }
    }

}
