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

    [SerializeField]
    Tilemap tilemap;


    void FixedUpdate(){

        MovementEnemy();

        Detection();

        nextPos = transform.position;
    }

    void MovementEnemy() {

        System.Random randomNumber = new System.Random();

        float playerPositionX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        float playerPositionY = GameObject.FindGameObjectWithTag("Player").transform.position.y;

        float enemyPositionX = GameObject.FindGameObjectWithTag("Enemy").transform.position.x;
        float enemyPositionY = GameObject.FindGameObjectWithTag("Enemy").transform.position.y;

        if (playerPositionX > enemyPositionX && playerPositionY > enemyPositionY) {
            int generateRandom = randomNumber.Next(1, 3);
            if (generateRandom == 1) //if random number is one AND the tile is free?
            {
                nextPos.y += 1f;
            }
            else if (generateRandom == 2) //if random number is two AND the tile is free?
            {
                nextPos.x += 1f;
            }
        }
        else if(playerPositionX > enemyPositionX && playerPositionY < enemyPositionY) {
            int generateRandom = randomNumber.Next(2, 4);
            if (generateRandom == 2)
            {
                nextPos.x += 1f;
            }
            else if (generateRandom == 3)
            {
                nextPos.y -= 1f;
            }
        }
        else if (playerPositionX < enemyPositionX && playerPositionY < enemyPositionY) {
            int generateRandom = randomNumber.Next(3, 5);
            if (generateRandom == 3)
            {
                nextPos.y -= 1f;
            }
            else if (generateRandom == 4)
            {
                nextPos.x -= 1f;
            }
        }
        else {
            int generateRandom = randomNumber.Next(4, 6);
            if (generateRandom == 4)
            {
                nextPos.x -= 1f;
            }
            else if (generateRandom == 5)
            {
                nextPos.y += 1f;
            }
        }

        moveTimer += Time.deltaTime;
        if(moveTimer >= 0.2f)
        {
            transform.position = nextPos;
            moveTimer = 0;
        }
    }

    void Detection() {

        hit = Physics2D.Raycast(transform.position, Vector3.up, 1f);
        Debug.DrawRay(transform.position, Vector3.up, Color.green, 1, false);
        hit = Physics2D.Raycast(transform.position, Vector3.right, 1f);
        Debug.DrawRay(transform.position, Vector3.right, Color.green, 1, false);
        hit = Physics2D.Raycast(transform.position, Vector3.down, 1f);
        Debug.DrawRay(transform.position, Vector3.down, Color.green, 1, false);
        hit = Physics2D.Raycast(transform.position, Vector3.left, 1f);
        Debug.DrawRay(transform.position, Vector3.left, Color.green, 1, false);

    }
}