using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{

    public float enemyKnockbackForce;
    public Rigidbody2D rb;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "EnemyCircle")
        {
            // creating the knockback here
            Vector2 enemyKnockback = enemyKnockbackForce * (collision.transform.position - transform.position).normalized;
            //adding a force to the created knockback
            collision.GetComponent<Rigidbody2D>().AddForce(enemyKnockback, ForceMode2D.Impulse);
            // sets the time last hit as the moment that the enemy has been hit and knocked back
            collision.GetComponent<CircleController>().timeLastHit = Time.time;
            Destroy(gameObject);
        }
    }
}
