using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using GA.Pyramid_dash;
using UnityEngine.SceneManagement;

namespace GA.Pyramid_dash {
    public class CharController : MonoBehaviour {

        [SerializeField]
        Tilemap tilemap;

        AudioSource audioData;

        public AudioClip digging_Sfx;
        public AudioClip death_Sfx;

        public AudioClip gem_Sfx;
        Animator animator;

        Vector3 nextPosition;

        RaycastHit2D hit;

        Vector3 pushPosition;

        RaycastHit2D push_Hit;

        float move_Timer;

        float move_Speed = 0.2f;

        bool move_Horizontal;

        [SerializeField]
        GameObject Tile_Animation_Prefab;

        [SerializeField]
        GameObject Gem_Particles_Prefab;

        [SerializeField]
        LevelController lC;

        [SerializeField]
        GameObject gameOver;

        // Start is called before the first frame update
        void Start() {
            audioData = GetComponent<AudioSource>();
            audioData.volume = PlayerPrefs.GetFloat("EffectVolume");
            animator = GetComponent<Animator>();
        }

        void FixedUpdate() {

            nextPosition = transform.position;

            if (Input.GetAxis("Vertical") < -0.7f) {
                nextPosition.y -= 1f;
                move_Horizontal = false;
                move_Timer += Time.deltaTime;
                animator.SetFloat("Move X", 0);
                animator.SetFloat("Move Y", -0.5f);
                
            } else if (Input.GetAxis("Vertical") > 0.7f) {
                nextPosition.y += 1f;
                move_Horizontal = false;
                move_Timer += Time.deltaTime;
                animator.SetFloat("Move X", 0);
                animator.SetFloat("Move Y", 0.5f);

            } else if (Input.GetAxis("Horizontal") < -0.7f) {
                nextPosition.x -= 1f;
                move_Horizontal = true;
                move_Timer += Time.deltaTime;
                animator.SetFloat("Move Y", 0);
                animator.SetFloat("Move X", -0.5f);
                
            } else if (Input.GetAxis("Horizontal") > 0.7f) {
                nextPosition.x += 1f;
                move_Horizontal = true;
                move_Timer += Time.deltaTime;
                animator.SetFloat("Move Y", 0);
                animator.SetFloat("Move X", 0.5f); 

            } else {
                move_Timer = 0.2f;
            }

            if (move_Timer >= move_Speed && nextPosition != transform.position) {
                Move(nextPosition, move_Horizontal);
                move_Timer = 0;
            }
            
        }

        void Move(Vector3 targetPosition, bool horizontal) {
            hit = Physics2D.Raycast(transform.position, targetPosition - transform.position, 1f, ~LayerMask.GetMask("Player", "Ignore Raycast"));
            Debug.DrawRay(transform.position, targetPosition - transform.position, Color.green, 2, false);
            if (hit.collider != null) {
                if (hit.transform.tag == "Tilemap") {
                    tilemap.SetTile(Vector3Int.FloorToInt(targetPosition), null);
                    transform.position = targetPosition;
                    GameObject Tile_Animation_Instance = Instantiate(Tile_Animation_Prefab, transform.position, Quaternion.identity);
                    if (PlayerPrefs.GetInt("DiggingSfx") == 1) {
                        audioData.PlayOneShot(digging_Sfx);
                    }

                } else if (hit.transform.tag == "Boulder" && horizontal) {
                    pushPosition = hit.transform.position - transform.position;
                    if (hit.collider.gameObject.GetComponent<BoulderController>().Pushed(pushPosition)) {
                        transform.position = targetPosition;
                    }
                } else if (hit.transform.tag == "Gem") {
                    Destroy(hit.transform.gameObject);
                    lC.AddScore();
                    transform.position = targetPosition;
                    audioData.PlayOneShot(gem_Sfx);
                    GameObject Gem_Particles_Instance = Instantiate(Gem_Particles_Prefab, transform.position, Quaternion.identity);

                } else if (hit.transform.tag == "Portal") {
                    if (hit.collider.gameObject.GetComponent<PortalController>().IsActive()) {
                        transform.position = targetPosition;
                    }
                }
            } else {
                transform.position = targetPosition;
            }
        }

        public void GameOver() {
            audioData.PlayOneShot(death_Sfx);
            gameOver.SetActive(true);
            StartCoroutine(Pause(2));
        }

        private IEnumerator Pause(int p) {
            Time.fixedDeltaTime = 5f;
            float pauseEndTime = Time.realtimeSinceStartup + p;
            while (Time.realtimeSinceStartup < pauseEndTime) {
                yield return 0;
            }
            Time.fixedDeltaTime = 0.02f;
            SceneManager.LoadScene("GameOver");
        }
    }
}
