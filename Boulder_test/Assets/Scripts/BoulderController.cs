using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderController : MonoBehaviour
{
    RaycastHit2D hit;
    Vector3 nextPosition;

    float fall_Timer;
    bool falling;

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
        hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1f, ~LayerMask.GetMask("Boulder"));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.green, 2, false);
        if (hit.collider != null) {
            fall_Timer = 0;
            falling = false;
            
        }  else {
            fall_Timer += Time.deltaTime;
        }

        if (fall_Timer >= 1.0f) {
            falling = true;
            transform.position = nextPosition;
            fall_Timer = 0;
        }
    }

}
