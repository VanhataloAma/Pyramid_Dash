using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
    public class InputManager : MonoBehaviour {
        [SerializeField]
        GameManager gm;

        [SerializeField]
        TMP_InputField inputField;

        public void ConfirmName() {
            string input = inputField.text;
            gm.SetName(input);
        }

    }
}