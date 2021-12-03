using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
    public class RollingEnemyController : MonoBehaviour {
        Vector3 nextPos;

        float moveTimer;

        RaycastHit2D hit;

        Vector3[] directions = new Vector3[4];

        int directionIndex = 0;
        int lastdirectionIndex = 0;


        // Start is called before the first frame update
        void Start() {
            directions[0] = Vector3.left;
            directions[1] = Vector3.up;
            directions[2] = Vector3.down;
            directions[3] = Vector3.right;
        }

        // Update is called once per frame
        void FixedUpdate() {
            moveTimer += Time.deltaTime;
            if (moveTimer >= 0.6f) {
                Move();
                moveTimer = 0f;
            }
            
        }

        void Opposites(Vector3 last) {
            for (int i = 0; i < directions.Length; i++) {
                if (directions[i] == last) {
                    Vector3 temp = directions[3];
                    directions[3] = last;
                    directions[i] = temp;
                }
            }
        }
        
        void Move() {
            nextPos = Vector3.zero;
            if (IsEmpty(directions[0])) {
                nextPos = directions[0];

            } else if (!IsEmpty(directions[1])) {
                for (int i = 1; i < directions.Length; i++) {
                    if (IsEmpty(directions[i])) {
                        nextPos = directions[i];
                        Vector3 temp = directions[1];
                        directions[1] = directions[0];
                        Vector3 temp2 = directions[i];
                        directions[i] = temp;
                        directions[0] = temp2;
                        break;
                    }
                }
            } else {
                Vector3 temp = directions[1];
                directions[1] = directions[0];
                directions[0] = temp;
                nextPos = directions[0];
            }

            if (directions[0] == Vector3.left && directions[3] != Vector3.right) {
                Opposites(Vector3.right);

            } else if (directions[0] == Vector3.right && directions[3] != Vector3.left) {
                Opposites(Vector3.left);

            } else if (directions[0] == Vector3.up && directions[3] != Vector3.down) {
                Opposites(Vector3.down);

            } else if (directions[0] == Vector3.down && directions[3] != Vector3.up) {
                Opposites(Vector3.up);

            }

            if (directions[0] == Vector3.right) {
                transform.eulerAngles = new Vector3(0, 180, 0);

            } else if (directions[0] == Vector3.left) {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
 
            //Debug.Log("Directions 2: " + directions[0] + " | " + directions[1] + " | " + directions[2] + " | " + directions[3]);
            /*if (!IsEmpty(directions[directionIndex])) {
                temp = lastdirectionIndex;
            } else {
                temp = directionIndex;
            }
            
            for (int i = 0; i < directions.Length; i++) {
                int pointer = (i + temp) % directions.Length;
                //Debug.Log("Pointer: " + pointer);
                //Debug.Log("Last: " + lastdirectionIndex);

                if (IsEmpty(directions[pointer])) {
                    nextPos = directions[pointer];
                    
                    if (directionIndex != pointer) {
                        lastdirectionIndex = directionIndex;
                    }
                    
                    directionIndex = pointer;
                    //Debug.Log("Index" + directionIndex);
                    if (pointer == 3) {
                        transform.eulerAngles = new Vector3(0, 180, 0);

                    } else if (pointer == 1) {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                    break;
                } else {
                    if (pointer == 0 || pointer == 2) {
                        temp = directions[0];
                        directions[0] = directions[2];
                        directions[2] = temp;
                    } else {
                        temp = directions[1];
                        directions[1] = directions[3];
                        directions[3] = temp;
                    }
                }

            }*/

            transform.position += nextPos;
        }

        bool IsEmpty(Vector3 target) {
            bool empty;

            hit = Physics2D.Raycast(transform.position, target, 1f, ~LayerMask.GetMask("Enemy"));
            Debug.DrawRay(transform.position, target, Color.green, 2, false);

            if (hit.collider != null) {
                if (hit.transform.tag == "Player") {
                    empty = true;
                } else {
                    empty = false;
                }
            } else {
                empty = true;
            }

            return empty;
        }

        int CycleInt(int subject, int min, int max) {
            if (subject > max) {
                subject = min;
            } else if (subject < min) {
                subject = max;
            }

            return subject;
        }

    }
}