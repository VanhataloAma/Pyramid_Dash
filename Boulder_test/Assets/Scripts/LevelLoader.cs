using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.Pyramid_dash {
    public class LevelLoader : MonoBehaviour {

        public Animator transition;

        public float transitionTime = 1f;

        public IEnumerator LoadLevel(string LevelName) {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(LevelName);

        }

    }
}