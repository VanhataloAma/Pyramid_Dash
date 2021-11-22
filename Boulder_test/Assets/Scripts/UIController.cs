using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GA.Pyramid_dash {
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text scoreText;

        [SerializeField]
        private TMP_Text gemsText;

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

        public void SetGems(int gems, int gemsMax) {
            gemsText.text = "Gems: " + gems + "/" + gemsMax;
        }
    }
}