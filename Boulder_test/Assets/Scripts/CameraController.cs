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

            if (transform.position.x - charaPosition.x > 8f) {
                MoveX = -0.17f;
            } else if (transform.position.x - charaPosition.x < -8f) {
                MoveX = 0.17f;
            }

            if (transform.position.y - charaPosition.y > 2.5f) {
                MoveY = -0.06f;
            } else if (transform.position.y - charaPosition.y < -2.5f) {
                MoveY = 0.06f;
            }

            transform.position += new Vector3(MoveX, MoveY, 0);
            transform.position += new Vector3(MoveX, MoveY, 0);
            transform.position += new Vector3(MoveX, MoveY, 0);

            if (Mathf.Abs(transform.position.y - charaPosition.y) <= 0.5f) {
                MoveY = 0f;
            }

            if (Mathf.Abs(transform.position.x - charaPosition.x) <= 1f) {
                MoveX = 0f;
            }
        }
    }
}