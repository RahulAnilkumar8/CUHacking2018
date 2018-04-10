using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitCollision : MonoBehaviour {
    // Use this for initialization

    private bool invincible = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!invincible)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                invincible = true;
                GameObject.FindGameObjectWithTag("HealthBar").GetComponent<PlayerHealth>().health--;

                float verticalPush = collision.gameObject.transform.position.y - transform.position.y;
                float horizontalPush = collision.gameObject.transform.position.x - transform.position.x;

                GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().AddForce(new Vector2(-horizontalPush,-verticalPush) * 50);

                Invoke("CancelInvincible", 0.75f);

            }
        }
    }


    void CancelInvincible() {
        invincible = false;
    }
}
