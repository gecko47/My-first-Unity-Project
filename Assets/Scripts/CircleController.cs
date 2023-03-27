using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{

    public GameObject target;
    public float circleSpeed;
    public float timeLastHit;

    public SpriteRenderer sprite;

    public int circleHealth;

    private void Start()
    {
        // target is reached by accessing the level manager's child: playercontroller contract
        target = transform.GetComponentInParent<LevelManager>().gameObject.GetComponentInChildren<PlayerController>().gameObject;

        circleHealth = 100;
    }

    void Update()
    {
        if (Time.time - timeLastHit > .3f)
        {
            // circle will move towards the player if the circle has been hit MORE than a second ago
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, circleSpeed * Time.deltaTime);
        }                  
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // if a bullet hits the enemyCircle, the FlashWhite is called by using "StartCoroutine"
            StartCoroutine(FlashWhite());

            circleHealth -= 25;

            if (circleHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public IEnumerator FlashWhite()
    {
        // changes the color of the enemyCircle to white briefly after it has been hit by a bullet, then back to its original color (red)
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        sprite.color = Color.red;

    }

}
