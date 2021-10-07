using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharController : MonoBehaviour
{
    public Tilemap tilemap;

    Vector3 nextPosition;

    RaycastHit2D hit;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        nextPosition = transform.position;

        if (Input.GetKeyDown("s")) {
            nextPosition.y -= 1f;
            Move(nextPosition);
            
        } else if (Input.GetKeyDown("w")) {
            nextPosition.y += 1f;
            Move(nextPosition);

        } else if (Input.GetKeyDown("a")) {
            nextPosition.x -= 1f;
            Move(nextPosition);
            
        } else if (Input.GetKeyDown("d")) {
            nextPosition.x += 1f;
            Move(nextPosition);  
        }
        
        tilemap.SetTile(Vector3Int.FloorToInt(transform.position), null);
    }

    void Move(Vector3 targetPosition) 
    {
        hit = Physics2D.Raycast(transform.position, targetPosition - transform.position, 1f, LayerMask.GetMask("Block"));
        Debug.DrawRay(transform.position, targetPosition - transform.position, Color.green, 2, false);
        if (hit.collider != null) {
            Debug.Log(hit.transform.tag);
        } else {
            transform.position = targetPosition;
        }
    }
    void OnCollisionEnter2D(Collision2D col) {
        //Debug.Log(col.collider);
    }
}
