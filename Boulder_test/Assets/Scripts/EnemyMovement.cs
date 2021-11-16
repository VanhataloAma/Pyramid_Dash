using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GA.Pyramid_dash;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 nextPos;
    float moveTimer;

    void FixedUpdate()
    {

        nextPos = transform.position;

        System.Random randomNumber = new System.Random();
        //int generateRandom = randomNumber.Next(1, 5);
        //Debug.Log("Number" + generateRandom);
        // 1=up, 2=right, 3=down, 4=left (also)5=up


        /*if (generateRandom == 1)
        {
            nextPos.y += 1f;
        }
        else if (generateRandom == 2)
        {
            nextPos.x += 1f;
        }
        else if (generateRandom == 3)
        {
            nextPos.y -= 1f;
        }
        else if (generateRandom == 4)
        {
            nextPos.x -= 1f;
        }*/

        float playerPositionX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        float playerPositionY = GameObject.FindGameObjectWithTag("Player").transform.position.y;

        if (playerPositionX >= 0 && playerPositionY >= 0) {
            int generateRandom = randomNumber.Next(1, 3);
            if (generateRandom == 1)
            {
                nextPos.y += 1f;
            }
            else if (generateRandom == 2)
            {
                nextPos.x += 1f;
            }
        }
        else if(playerPositionX >= 0 && playerPositionY <= 0) {
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
        else if (playerPositionX <= 0 && playerPositionY <= 0) {
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
        if(moveTimer >= 2.0f)
        {
            transform.position = nextPos;
            moveTimer = 0;
        }
    }
}