using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.Pyramid_dash {
    public class LevelLoader : MonoBehaviour {

        public Animator transition;

        public IEnumerator LoadLevel(string LevelName, float transitionTime) {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(LevelName);

        }

        public IEnumerator LoadLevel(int LevelIndex, float transitionTime) {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(LevelIndex);

        }

    }
}