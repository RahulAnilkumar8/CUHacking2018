using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int health = 3;

    
    public Sprite[] heartSprite;


	// Use this for initialization
	void Start () {
        this.GetComponent<SpriteRenderer>().sprite = heartSprite[0];
    }
	
	// Update is called once per frame
	void Update () {
        if (health == 0) {
            this.GetComponent<SpriteRenderer>().sprite = heartSprite[3];
            DestroyObject(GameObject.FindGameObjectWithTag("Player"));

        }
        else if (health == 1) {
            this.GetComponent<SpriteRenderer>().sprite = heartSprite[2];
        }
        else if (health == 2)
        {
            this.GetComponent<SpriteRenderer>() .sprite = heartSprite[1];
        }
        else if (health == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = heartSprite[0];
        }
    }

    


}
