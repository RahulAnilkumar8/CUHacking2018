using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRigidBody2D : MonoBehaviour {
    Rigidbody2D wallRigid;

    // Use this for initialization
    void Start()
    {
        wallRigid = GetComponent<Rigidbody2D>();
        wallRigid.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
