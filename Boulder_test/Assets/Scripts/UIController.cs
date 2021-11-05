using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GA.Pyramid_dash {
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text scoreText;

        private static UIController current;

        public static UIController Current {
            get { return current; }
        }

        private void Awake() {
            current = this;
        }

        public void SetScore(int score) {
            scoreText.text = "Score: " + score;
        }

    }
}