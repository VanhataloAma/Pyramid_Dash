using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GA.Pyramid_dash;
using TMPro;

namespace GA.Pyramid_dash {
    public class LevelComplete : MonoBehaviour {
        [SerializeField]
        TMP_Text gemsText;

        [SerializeField]
        TMP_Text timeText;

        [SerializeField]
        TMP_Text totalText;
        // Start is called before the first frame update
        void Start() {
            gemsText.text = "Gems: " + LevelController.levelScore;
            timeText.text = "Time: " + (int)LevelController.timeLeft;
            totalText.text = "Total Score: " + LevelController.levelScore + (int)LevelController.timeLeft;
            
        }

        // Update is called once per frame
        void Update() {
            
        }
    }
}