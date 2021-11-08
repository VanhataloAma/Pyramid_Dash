using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.Pyramid_dash {
    public class BoulderController : MonoBehaviour {
        RaycastHit2D hit;

        [SerializeField]
        GameObject MoveCheck_Prefab;
        GameObject MoveCheck_Instance;

        Vector3 nextPosition;
        Vector3 collapsePosition;

        Vector3 raycast_Start_Down;
        Vector3 raycast_Start_Left;
        Vector3 raycast_Start_Right;

        float fall_Timer;
        bool falling;

        Animator boulder_Animator;
        
        // Start is called before the first frame update
        void Start() {
            nextPosition = transform.position - new Vector3(0, 1, 0);
            boulder_Animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void FixedUpdate() {
            Move();
        }

        void Move() {
            Destroy(MoveCheck_Instance);
            
            nextPosition = transform.position - new Vector3(0, 1, 0);

            raycast_Start_Down = transform.position;
            raycast_Start_Down.y -= 0.35f;

            raycast_Start_Left = transform.position;
            raycast_Start_Left.x -= 0.35f;

            raycast_Start_Right = transform.position;
            raycast_Start_Right.x += 0.35f;

            hit = Physics2D.Raycast(raycast_Start_Down, nextPosition - transform.position, 0.6f);
            Debug.DrawRay(raycast_Start_Down, nextPosition - transform.position, Color.green, 2, false);
            if (hit.collider != null) {
                if (hit.transform.tag == "Player") {
                    if (!falling) {
                        fall_Timer = 0.2f;
                    } else {
                        fall_Timer += Time.deltaTime;
                    }

                } else {
                    falling = false;
                }

                if (hit.transform.tag == "Boulder" && !falling) {
                    collapsePosition = Collapse();
                    boulder_Animator.SetBool("Collapsing", true);
                    if (collapsePosition != transform.position) {
                        boulder_Animator.SetBool("Collapsing", false);
                        nextPosition = collapsePosition;
                        fall_Timer += Time.deltaTime;
                    }
                } else {
                    boulder_Animator.SetBool("Collapsing", false);
                }
                
            }  else {
                fall_Timer += Time.deltaTime;
            }

            if (fall_Timer >= 0.25f) {
                falling = true;
                transform.position = nextPosition;
                MoveCheck_Instance = Instantiate(MoveCheck_Prefab, transform.position, Quaternion.identity);
                fall_Timer = 0;
                
            }
        }

        Vector3 Collapse() {
            Vector3 collapse_Position = transform.position;
            bool changed = false;
            hit = Physics2D.Raycast(raycast_Start_Down, new Vector3(-1, -1, 0), 1f);
            Debug.DrawRay(raycast_Start_Down, new Vector3(-1, -1, 0), Color.red, 2, false);
            if (hit.collider == null) {
                hit = Physics2D.Raycast(raycast_Start_Left, new Vector3(-1, 0, 0), 1f);
                Debug.DrawRay(raycast_Start_Left, new Vector3(-1, 0, 0), Color.magenta, 2, false);
                if (hit.collider == null) {
                    collapse_Position += new Vector3(-1, 0, 0);
                    changed = true;
                }
            }

            if (!changed) {
                hit = Physics2D.Raycast(raycast_Start_Down, new Vector3(1, -1, 0), 1f);
                Debug.DrawRay(raycast_Start_Down, new Vector3(1, -1, 0), Color.yellow, 2, false);
                if (hit.collider == null) {
                    hit = Physics2D.Raycast(raycast_Start_Right, new Vector3(1, 0, 0), 1f);
                    Debug.DrawRay(raycast_Start_Right, new Vector3(1, 0, 0), Color.cyan, 2, false);
                    if (hit.collider == null) {
                        collapse_Position += new Vector3(1, 0, 0);
                    }
                }
            }
            return collapse_Position;
        }

        void OnCollisionEnter2D(Collision2D col) {
            if (col.transform.tag == "Player" && falling) {
                SceneManager.LoadScene("GameOver");
            }
        }

        public bool Pushed(Vector3 pushDirection) {
            //Debug.Log(pushDirection);
            RaycastHit2D push_Hit = Physics2D.Raycast(transform.position + pushDirection, pushDirection * -1, 0.5f);
            Debug.DrawRay(transform.position + pushDirection,pushDirection * -1, Color.blue, 10, false);
            if (push_Hit.collider == null) {
                transform.position += pushDirection;
                return true;
            } else {
                Debug.Log(hit.transform.tag);
                return false;
            }
        }

    }
}