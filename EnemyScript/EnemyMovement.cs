using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour {

    public float attackMovementSpeed;
    public float idleMovementSpeed;

    private float time = 0;
    private bool update = true;
    private float randomValue = Random.value;

    Transform target;
    Vector3 targetDistance;

    private void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate () {
        time += Time.deltaTime;
        if (update)
        {
            randomValue = Random.value;
            update = false;
            target = GameObject.Find("Player 1(Clone)").transform;
            targetDistance = target.position - transform.position;
            Invoke("updateEnemy", 1);
        }

        if (time <= 2f)
        {
            if (time <=1f) {
                if (targetDistance.magnitude < 5)
                {
                    StartCoroutine(attackMovement(targetDistance, 0f));
                    movement(new Vector3(0f, 0f, 0f), 0);
                }
                else
                {
                    StartCoroutine(idleMovement(0f, randomValue));
                    movement(new Vector3(0f, 0f, 0f), 0);
                }
            }
        }
        else if (time >= 2f)
        {
            time = 0.0f;
        }


    }

    void updateEnemy()
    {
        update = true;
    }


    IEnumerator idleMovement(float delayTime, float randomValue) {
        yield return new WaitForSeconds(delayTime);
        if (randomValue < 0.25)
        {
            movement(new Vector3(0f, 1f, 0f), idleMovementSpeed);
        }
        else if (randomValue < 0.5)
        {
            movement(new Vector3(1f, 0f, 0f), idleMovementSpeed);
        }
        else if (randomValue < 0.75)
        {
            movement(new Vector3(0f, -1f, 0f), idleMovementSpeed);
        }
        else if (randomValue < 1)
        {
            movement(new Vector3(-1f, 0f, 0f), idleMovementSpeed);
        }
    }

    IEnumerator attackMovement(Vector3 direction, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        movement(direction, attackMovementSpeed);
    }

    public void movement(Vector3 direction, float speed) {
        transform.position = (direction * speed * Time.deltaTime) + transform.position;
    }
}

/*
 *     
 

            
     
     */
