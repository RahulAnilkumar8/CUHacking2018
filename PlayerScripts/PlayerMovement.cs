using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float movementSpeed;
    
	
	// Update is called once per frame
	void FixedUpdate () {
               
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        if (horizontalMovement > 0) {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        float xpos = horizontalMovement * movementSpeed * Time.deltaTime;
        float ypos = verticalMovement * movementSpeed * Time.deltaTime;

        transform.position += new Vector3(xpos, ypos,0);

        
    }
}
