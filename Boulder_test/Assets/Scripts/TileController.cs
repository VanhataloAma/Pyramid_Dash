using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        anim.Play("New Animation");
    }

    void Update() {
        if (!anim.IsPlaying("New Animation")) {
            Destroy(gameObject);
        }
    }

}