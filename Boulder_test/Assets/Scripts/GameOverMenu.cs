using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
    public class GameOverMenu : MonoBehaviour {

        public void RestartLevel() {
            SceneManager.LoadScene(LevelController.current_Level_Index);
        }

        public void QuitGame() {
            SceneManager.LoadScene("Menu");
        }

    }
}