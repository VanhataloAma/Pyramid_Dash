using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GA.Pyramid_dash;
using UnityEngine.SceneManagement;

namespace GA.Pyramid_dash {

    public class HighScoreController : MonoBehaviour {
        [SerializeField]
        private TMP_Text entryTemplate;

        // Start is called before the first frame update
        void Start() {
            Score score = new Score(GameConfig.GetHighScorePath());

            for (int i = 0; i < GameConfig.ScoreEntryCount; i++) {
                var scoreEntry = score.GetEntry(i);
                var item = Instantiate(entryTemplate, transform);

                item.text = i + 1 + ". " + scoreEntry.Name + " : " + scoreEntry.Score;

                Vector2 position = entryTemplate.rectTransform.anchoredPosition;
                position.y = -i * 36;
                item.rectTransform.anchoredPosition = position;
                if (scoreEntry.Score > 0) {
                    item.gameObject.SetActive(true);
                }
                
            }
        }

        public void BackToMenu() {
            SceneManager.LoadScene("Menu");
        }
    }
}