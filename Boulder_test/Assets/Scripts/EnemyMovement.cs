using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
public class EnemyMovement : MonoBehaviour {
        private Vector3 nextPos;
        
        float moveTimer;

        RaycastHit2D hit;

        Vector3 playerPos;

        float distanceFromPlayer;

        bool moved;

        Vector3[] directions = new Vector3[4];


        void Start() {
            directions[0] = Vector3.left;
            directions[1] = Vector3.up;
            directions[2] = Vector3.down;
            directions[3] = Vector3.right;
        }

        void FixedUpdate(){
            moveTimer += Time.deltaTime;
            if (moveTimer >= 0.6f) {
                MovementEnemy();
                moveTimer = 0f;
            }
            nextPos = new Vector3(0, 0, 0);
        }

        void MovementEnemy() {
            moved = false;

            System.Random randomNumber = new System.Random();

            playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            distanceFromPlayer = Vector3.Distance(transform.position, playerPos);

            int rand = randomNumber.Next(0, 4);
            for (int i = 0; i < directions.Length; i++) {
                int index = (i + rand) % directions.Length;
                checkDirection(directions[index]);
            }


            transform.position += nextPos;
        }

        void checkDirection(Vector3 dir) {
            if (IsEmpty(dir) && !moved || IsEmpty(dir) && Vector3.Distance(transform.position + dir, playerPos) < distanceFromPlayer) {
                Debug.Log("Direction : " + dir + "Distance: " + Vector3.Distance(transform.position + dir, playerPos));
                moved = true;
                distanceFromPlayer = Vector3.Distance(transform.position + dir, playerPos);
                nextPos = dir;
            }
        }

        bool IsEmpty(Vector3 target) {
            bool empty;

            hit = Physics2D.Raycast(transform.position, target, 1f, ~LayerMask.GetMask("Enemy", "Ignore Raycast"));
            Debug.DrawRay(transform.position, target, Color.green, 2, false);

            if (hit.collider != null) {
                if (hit.transform.tag == "Player") {
                    empty = true;
                } else {
                    empty = false;
                }
            } else {
                empty = true;
            }

            return empty;
        }
    }
}