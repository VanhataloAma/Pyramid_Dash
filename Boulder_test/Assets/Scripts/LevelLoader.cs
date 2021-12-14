using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.Pyramid_dash {
    public class LevelLoader : MonoBehaviour {

        public Animator transition;

        void Start() {
            //StartCoroutine(StartDelay());
        }

        public IEnumerator StartDelay() {
            Time.fixedDeltaTime = 5f;

            yield return new WaitForSeconds(0.5f);

            Time.fixedDeltaTime = 0.02f;
        }

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