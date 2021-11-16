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
        int generateRandom = randomNumber.Next(1, 5);
        Debug.Log("Number" + generateRandom);
        // 1=up, 2=right, 3=down, 4=left


        if (generateRandom == 1)
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
        }

        moveTimer += Time.deltaTime;
        if(moveTimer >= 2.0f)
        {
            transform.position = nextPos;
            moveTimer = 0;
        }
    }
}