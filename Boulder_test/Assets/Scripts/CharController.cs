using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GA.Pyramid_dash {
    public class CharController : MonoBehaviour {

        [SerializeField]
        Tilemap tilemap;

        AudioSource audioData;

        Vector3 nextPosition;

        RaycastHit2D hit;

        Vector3 pushPosition;

        RaycastHit2D push_Hit;

        float move_Timer;

        [SerializeField]
        float move_Speed = 0.25f;

        bool move_Horizontal;

        float vertical_Axis;
        float horizontal_Axis;

        // Start is called before the first frame update
        void Start() {
            audioData = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update() {
            vertical_Axis = Input.GetAxis("Vertical");
            horizontal_Axis = Input.GetAxis("Horizontal");

            nextPosition = transform.position;

            if (Input.GetKey("s")) {
                nextPosition.y -= 1f;
                move_Horizontal = false;
                move_Timer += Time.deltaTime;
                
            } else if (Input.GetKey("w")) {
                nextPosition.y += 1f;
                move_Horizontal = false;
                move_Timer += Time.deltaTime;
                //Move(nextPosition, false);

            } else if (Input.GetKey("a")) {
                nextPosition.x -= 1f;
                move_Horizontal = true;
                move_Timer += Time.deltaTime;
                //Move(nextPosition, true);
                
            } else if (Input.GetKey("d")) {
                nextPosition.x += 1f;
                move_Horizontal = true;
                move_Timer += Time.deltaTime;
                //Move(nextPosition, true);  

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
                Debug.Log(hit.collider);
                if (hit.transform.tag == "Tilemap") {
                    tilemap.SetTile(Vector3Int.FloorToInt(targetPosition), null);
                    transform.position = targetPosition;

                } else if (hit.transform.tag == "Boulder" && horizontal) {
                    pushPosition = hit.transform.position - transform.position;
                    if (hit.collider.gameObject.GetComponent<BoulderController>().Pushed(pushPosition)) {
                        transform.position = targetPosition;
                    }
                } else if (hit.transform.tag == "Gem") {
                    Destroy(hit.transform.gameObject);
                    transform.position = targetPosition;

                } else if (hit.transform.tag == "Portal") {
                    transform.position = targetPosition;
                }
            } else {
                transform.position = targetPosition;
            }
        }
    }
}
