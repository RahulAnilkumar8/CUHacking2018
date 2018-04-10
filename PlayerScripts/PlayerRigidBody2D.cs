using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidBody2D : MonoBehaviour {

    Rigidbody2D playerRigid;

    // Use this for initialization
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        playerRigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
