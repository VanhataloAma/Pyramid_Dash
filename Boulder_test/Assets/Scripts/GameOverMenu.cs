using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
    public class GameOverMenu : MonoBehaviour{

        private float timer = 2.5f;
        
        void Update() {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("Menu");
                Debug.Log("Times up");
            }
        }

    }
}