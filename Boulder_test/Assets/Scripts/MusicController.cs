using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
    public class MusicController : MonoBehaviour {
        private AudioSource audi;

        void Start() {
            audi = GetComponent<AudioSource>();
        }

        void Update() {
            audi.volume = PlayerPrefs.GetFloat("MusicVolume");
        }

    }
}