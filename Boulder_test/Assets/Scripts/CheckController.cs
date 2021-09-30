using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckController : MonoBehaviour
{
    Collider2D coll;

    public bool isBlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log(other.transform.tag);

        if (other.transform.tag.Equals("block")) {
            isBlocked = true;
            Debug.Log("akfgsdg");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool GetIsBlocked() 
    {
        //Debug.Log(isBlocked);
        return isBlocked;
    }

}
