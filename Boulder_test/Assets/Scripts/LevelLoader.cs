using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.Pyramid_dash {
    public class LevelLoader : MonoBehaviour {

        public Animator transition;

        public IEnumerator LoadLevel(string LevelName, float transitionTime) {
            transition.SetTrigger("Start");

            Time.fixedDeltaTime = 5f;

            yield return new WaitForSeconds(transitionTime);

            Time.fixedDeltaTime = 0.02f;

            SceneManager.LoadScene(LevelName);

        }

        public IEnumerator LoadLevel(int LevelIndex, float transitionTime) {
            transition.SetTrigger("Start");

            Time.fixedDeltaTime = 5f;

            yield return new WaitForSeconds(transitionTime);

            Time.fixedDeltaTime = 0.02f;

            SceneManager.LoadScene(LevelIndex);

        }

    }
}