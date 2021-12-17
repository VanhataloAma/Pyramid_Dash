using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GA.Pyramid_dash;
using TMPro;

namespace GA.Pyramid_dash {
    public class VictoryController : MonoBehaviour {
        [SerializeField]
        LevelLoader loader;

        [SerializeField]
        TMP_Text exitText;

        AudioSource audi;
        // Start is called before the first frame update
        void Start() {
            StartCoroutine(StartDelay());
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetButton("Submit")) {
                StartCoroutine(loader.LoadLevel("Menu", 1f));
            }
        }

        public IEnumerator StartDelay() {
            yield return new WaitForSeconds(5f);

            exitText.gameObject.SetActive(true);
        }
    }
}