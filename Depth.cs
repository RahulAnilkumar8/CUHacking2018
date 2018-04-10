using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depth : MonoBehaviour {


    private float xPosition;
    private float yPosition;

	// Update is called once per frame
	void Update () {
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        transform.position = new Vector3(xPosition, yPosition, yPosition);

	}
}
