using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    Transform target;

    void Start()
    {
        target = GameObject.Find("Player 1(Clone)").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + new Vector3(0, 0, -10);
    }
}

