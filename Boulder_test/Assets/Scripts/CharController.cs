using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharController : MonoBehaviour
{
    public Tilemap tilemap;
    AudioSource audioData;

    Vector3 nextPosition;

    RaycastHit2D hit;
    
    // Start is called before the first frame update
    void Start()
    {
     audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        nextPosition = transform.position;

        if (Input.GetKeyDown("s")) {
            nextPosition.y -= 1f;
            Move(nextPosition, false);
            
        } else if (Input.GetKeyDown("w")) {
            nextPosition.y += 1f;
            Move(nextPosition, false);

        } else if (Input.GetKeyDown("a")) {
            nextPosition.x -= 1f;
            Move(nextPosition, true);
            
        } else if (Input.GetKeyDown("d")) {
            nextPosition.x += 1f;
            Move(nextPosition, true);  
        }
        
        
    }

    void Move(Vector3 targetPosition, bool horizontal) 
    {
        hit = Physics2D.Raycast(transform.position, targetPosition - transform.position, 1f, ~LayerMask.GetMask("Player"));
        Debug.DrawRay(transform.position, targetPosition - transform.position, Color.green, 2, false);
        if (hit.collider != null) {
            Debug.Log(hit.transform.tag);
            if (hit.transform.tag == "Tilemap") {
                tilemap.SetTile(Vector3Int.FloorToInt(targetPosition), null);
                transform.position = targetPosition;

            } else if (hit.transform.tag == "Boulder" && horizontal) {
            }
        } else {
            transform.position = targetPosition;
        }
    }
    void OnCollisionEnter2D(Collision2D col) {
        //Debug.Log(col.collider);
    }
}
