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
        int activation_Threshold;

        [SerializeField]
        string next_Level;

        GameObject[] gems;

        Collider2D portalCollider;

        [SerializeField]
        Collider2D playerCollider;

        [SerializeField]
        Sprite activatedSprite;

        SpriteRenderer srenderer;

        // Start is called before the first frame update
        void Start()
        {
            portalCollider = GetComponent<Collider2D>();
            srenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            gems = GameObject.FindGameObjectsWithTag("Gem");
            if (gems.Length <= activation_Threshold) {
                active = true;
                srenderer.sprite = activatedSprite;
            }
            if (portalCollider.bounds.Intersects(playerCollider.bounds) && active) {
                SceneManager.LoadScene(next_Level);
            }
        }

        public bool IsActive() {
            return active;
        }
    }
}
