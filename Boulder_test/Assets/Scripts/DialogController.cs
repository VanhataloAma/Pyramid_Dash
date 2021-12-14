using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
    public class DialogController : MonoBehaviour {
        [SerializeField]
        LevelLoader loader;

        // Start is called before the first frame update
        void Start() {
            
        }

        // Update is called once per frame
        void Update() {
            
        }

        public void Nextlevel(string nextLevel) {
            StartCoroutine(loader.LoadLevel(nextLevel, 1f));
        }

    }
}