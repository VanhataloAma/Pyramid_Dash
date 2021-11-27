using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GA.Pyramid_dash;
using Cinemachine;

namespace GA.Pyramid_dash {
    public class CameraController : MonoBehaviour {

        [SerializeField]
        CharController character;

        Vector3 charaPosition;

        float MoveX = 0;
        float MoveY = 0;

        // Update is called once per frame
        void FixedUpdate() {
            charaPosition = character.transform.position;

            if (transform.position.x - charaPosition.x > 9f) {
                MoveX = -0.5f;
            } else if (transform.position.x - charaPosition.x < -9f) {
                MoveX = 0.5f;
            }

            if (transform.position.y - charaPosition.y > 4.5f) {
                MoveY = -0.25f;
            } else if (transform.position.y - charaPosition.y < -4.5f) {
                MoveY = 0.25f;
            }

            transform.position += new Vector3(MoveX, MoveY, 0);

            if ((int)transform.position.y == (int)charaPosition.y) {
                MoveY = 0f;
            }

            if ((int)transform.position.x == (int)charaPosition.x) {
                MoveX = 0f;
            }
        }
    }
}