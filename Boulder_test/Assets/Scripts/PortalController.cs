using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField]
    bool active = false;

    [SerializeField]
    int activation_Threshold;

    GameObject[] gems;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gems = GameObject.FindGameObjectsWithTag("Gem");
        if (gems.Length == activation_Threshold) {
            active = true;
        }
    }
}
