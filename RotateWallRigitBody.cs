using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWallRigitBody : MonoBehaviour {

    Rigidbody2D wallRigidRotate;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        wallRigidRotate = GetComponent<Rigidbody2D>();
        wallRigidRotate.constraints = RigidbodyConstraints2D.FreezePosition;
        transform.Rotate(new Vector3(0,0,1));
        //transform.Rotate(Vector3.up);
    }
}
