using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
    public class CreditsController : MonoBehaviour {
        [SerializeField]
        LevelLoader loader;

        // Start is called before the first frame update
        public void QuitToMenu() {
            StartCoroutine(loader.LoadLevel("Menu", 1f));
        }
    }
}