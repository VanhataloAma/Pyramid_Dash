using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace GA.Pyramid_dash {
    public class VCamController : MonoBehaviour {

        CinemachineVirtualCamera vcam;
        CinemachineFramingTransposer framingTransposer;

        public Camera cam;

        bool MoveX = false;
        bool MoveY = false;

        Vector3 characterPosition;

        Vector3 cameraPosition;
        // Start is called before the first frame update
        void Start() {
            vcam = GetComponent<CinemachineVirtualCamera>();
            framingTransposer = GetComponentInChildren<CinemachineFramingTransposer>();
            Debug.Log(vcam.m_Follow.tag);
            SetUpFramingTransposer();
        }

        // Update is called once per frame
        void FixedUpdate() {
            characterPosition = vcam.m_Follow.position;
            cameraPosition = cam.transform.position;

            if (Mathf.Abs(cameraPosition.y - characterPosition.y) > 2.5f) {
                MoveY = true;
            } else if (Mathf.Abs(cameraPosition.y - characterPosition.y) <= 0.5f) {
                MoveY = false;
            }
            //Debug.Log(Mathf.Abs(transform.position.y - characterPosition.y));

            if (Mathf.Abs(cameraPosition.x - characterPosition.x) > 5.5f) {
                MoveX = true;
            } else if (Mathf.Abs(cameraPosition.x - characterPosition.x) <= 1f) {
                MoveX = false;
            }

            Debug.Log(Mathf.Abs(cameraPosition.x - characterPosition.x));

            if (MoveY) {
                framingTransposer.m_DeadZoneHeight = 0f;
                //transform.position = new Vector3(transform.position.x, characterPosition.y, transform.position.z);
            } else {
                framingTransposer.m_DeadZoneHeight = 1f;
            }

            if (MoveX) {
                framingTransposer.m_DeadZoneWidth = 0f;
            } else {
                framingTransposer.m_DeadZoneWidth = 1f;
            }

            //framingTransposer.m_DeadZoneHeight = 0f;
        }

        void SetUpFramingTransposer() {
            framingTransposer.m_XDamping = 1.5f;
            framingTransposer.m_YDamping = 1.5f;
            framingTransposer.m_SoftZoneHeight = 1f;
            framingTransposer.m_SoftZoneWidth = 1f;
        }
    }
}