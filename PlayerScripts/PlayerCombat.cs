using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    public GameObject weapon;
    Transform weaponInstance;
	
	// Update is called once per frame
	void FixedUpdate () {
        attack();
	}

    public void attack() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");
            Vector3 weaponOffset = new Vector3(horizontalMovement, verticalMovement);
            Vector3 position = GameObject.FindGameObjectWithTag("Player").transform.position;
            weapon = (GameObject)Instantiate(weapon, weaponOffset + position, Quaternion.identity);
        }
    }
}
