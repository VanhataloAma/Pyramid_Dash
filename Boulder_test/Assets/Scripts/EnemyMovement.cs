using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using GA.Pyramid_dash;

public class EnemyMovement : MonoBehaviour {
    private Vector3 nextPos;
    float moveTimer;
    RaycastHit2D hit;

    void FixedUpdate(){
        MovementEnemy();
        nextPos = new Vector3(0, 0, 0);
    }

    void MovementEnemy() {

        System.Random randomNumber = new System.Random();

        float playerPositionX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        float playerPositionY = GameObject.FindGameObjectWithTag("Player").transform.position.y;

        float enemyPositionX = GameObject.FindGameObjectWithTag("Enemy").transform.position.x;
        float enemyPositionY = GameObject.FindGameObjectWithTag("Enemy").transform.position.y;

        float moveX = 0;
        float moveY = 0;

        if (playerPositionX > enemyPositionX)
        {
            moveX = 1;
        }
        else
        {
            moveX = -1;
        }
        if (playerPositionY > enemyPositionY)
        {
            moveY = 1;
        }
        else
        {
            moveY = -1;
        }

        int generateRandom = randomNumber.Next(1, 3);
        if(generateRandom == 1)
        {
            nextPos.x += moveX;
        }
        else
        {
            nextPos.y += moveY;
        }
        moveTimer += Time.deltaTime;
        if(moveTimer >= 0.5f)
        {
            Detection();
            moveTimer = 0;
        }
    }

    void checkHit(RaycastHit2D hit) {

        if (hit.collider != null)
        {
            //Debug.Log(hit.transform.tag);
            if (hit.transform.tag == "Player")
            {
                transform.position += nextPos;
            }
        }
        else
        {
            transform.position += nextPos;
            //Debug.Log("yey");
        }
    }

    void Detection() {
        //Debug.Log(nextPos);
        hit = Physics2D.Raycast(transform.position, nextPos, 1f, ~LayerMask.GetMask("Enemy"));
        Debug.DrawRay(transform.position, nextPos, Color.green, 1, false);

        checkHit(hit);
    }
}