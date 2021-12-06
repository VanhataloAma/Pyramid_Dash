using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
    public class TileController : MonoBehaviour {
        Animation anim;
        Animator animator;
        // Start is called before the first frame update
        void Start() {
            anim = GetComponent<Animation>();
            anim.Play("New Animation");
            animator = GetComponent<Animator>();
            animator.SetInteger("index", GameObject.Find("LevelController").GetComponent<LevelController>().sandColor);
        }

        void Update() {
            if (!anim.IsPlaying("New Animation")) {
                Destroy(gameObject);
            }
        }

    }
}