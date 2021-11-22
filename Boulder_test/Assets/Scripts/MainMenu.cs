using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        GameManager gm;

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
            SceneManager.LoadScene(level_Name);
        }

    }
}