using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.Pyramid_dash
{
    public class MainMenu : MonoBehaviour
    {

        public void PlayGame ()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitGame ()
        {
            Debug.Log("This won't happen inside unity editor, but we did indeed, rage quit");
            Application.Quit();
        }

    }
}