using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.Pyramid_dash {

    public class PauseController : MonoBehaviour {

        public void QuitToMenu() {
            SceneManager.LoadScene("Menu");
        }

        public void RestartLevel() {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }

}
