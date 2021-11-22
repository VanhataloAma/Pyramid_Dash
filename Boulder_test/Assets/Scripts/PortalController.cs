using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.Pyramid_dash
{
    public class PortalController : MonoBehaviour
    {
        [SerializeField]
        bool active = false;

        [SerializeField]
        string next_Level;

        Collider2D portalCollider;

        [SerializeField]
        Collider2D playerCollider;

        [SerializeField]
        Sprite activatedSprite;

        SpriteRenderer srenderer;

        private Animator anim;
        private AudioSource audi;

        // Start is called before the first frame update
        void Start()
        {
            portalCollider = GetComponent<Collider2D>();
            srenderer = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            audi = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if (portalCollider.bounds.Intersects(playerCollider.bounds) && active) {
                SceneManager.LoadScene(next_Level);
            }
        }

        public void Activate() {
            active = true;
            anim.Play("Base Layer.Portal_Flicker", 0, 0);
            audi.Play(0);
            srenderer.sprite = activatedSprite;
        }

        public bool IsActive() {
            return active;
        }
    }
}
