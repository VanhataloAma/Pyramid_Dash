using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoulderController : MonoBehaviour
{
    RaycastHit2D hit;

    Vector3 nextPosition;
    Vector3 raycast_Start;

    float fall_Timer;
    bool falling;
    bool onPlayer = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        nextPosition = transform.position;
        nextPosition.y -= 1f;
        raycast_Start = transform.position;
        raycast_Start.y -= 0.3f;
        hit = Physics2D.Raycast(raycast_Start, transform.TransformDirection(Vector3.down), 1f);
        Debug.DrawRay(raycast_Start, transform.TransformDirection(Vector3.down), Color.green, 2, false);
        if (hit.collider != null) {
            if (hit.transform.tag == "Player") {
                if (!falling) {
                    onPlayer = true;
                    fall_Timer = 0.39f;
                } else {
                    if (onPlayer) {
                        fall_Timer = 0.4f;
                        onPlayer = false;
                    }
                    fall_Timer += Time.deltaTime;
                }

            } else {
                falling = false;
            }

            if (hit.transform.tag == "Boulder") {
                fall_Timer = 0f;
                transform.position = Collapse();
            }
            
        }  else {
            fall_Timer += Time.deltaTime;
        }

        if (fall_Timer >= 0.4f) {
            falling = true;
            transform.position = nextPosition;
            fall_Timer = 0;
        }
    }

    Vector3 Collapse() {
        Vector3 collapse_Position = transform.position;
        hit = Physics2D.Raycast(raycast_Start, new Vector3(-1, -1, 0), 1f);
        Debug.DrawRay(raycast_Start, new Vector3(-1, -1, 0), Color.red, 10, false);
        if (hit.collider == null) {
            hit = Physics2D.Raycast(raycast_Start, new Vector3(-1, 0, 0), 1f);
            Debug.DrawRay(raycast_Start, new Vector3(-1, 0, 0), Color.magenta, 10, false);
            if (hit.collider == null) {
                collapse_Position += new Vector3(-1, 0, 0);
            }
        } else {
            hit = Physics2D.Raycast(raycast_Start, new Vector3(1, 0, 0), 1f);
            Debug.DrawRay(raycast_Start, new Vector3(1, 0, 0), Color.yellow, 10, false);
            if (hit.collider == null) {
                hit = Physics2D.Raycast(raycast_Start, new Vector3(1, -1, 0), 1f);
                if (hit.collider == null) {
                    collapse_Position += new Vector3(1, -1, 0);
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

}
