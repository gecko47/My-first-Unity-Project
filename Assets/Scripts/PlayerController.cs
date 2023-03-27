using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Camera sceneCamera;
    public float moveSpeed;
    public Rigidbody2D rb;
    public float timeLastShot;
    public Weapon weapon;
    public float dashSpeed;
    public float timeLastDashed;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthbar;

    public float circleKnockbackPower;

    private Vector2 moveDirection;
    private Vector2 mousePosition;


    private void Start()
    {
        // first we set current health to 100 (maxHealth). Then we also set the healthbar's max health to the max health.
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {       
        Move();
        Dash();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // fire weapon when left mouse button is held down  
        if(Input.GetMouseButton(0) && (Time.time - timeLastShot > .3f))
        { 
            weapon.Fire();
            timeLastShot = Time.time;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {
        rb.AddForce(new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed).normalized * 50);
        // Rotate player to follow mouse
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    // This function deals with the player taking damage from contact with an enemy.
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if (currentHealth == 0)
        {
            // if health hits 0, then the "Game Over" function is called.
            FindObjectOfType<LevelManager>().GameOver();
            
        }       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "EnemyCircle")
        {     
            // creates the player's knockback by subtracting the player's position from the enemy's position. uses opposite knockback to send the player away from enemy
            Vector2 playerKnockback = circleKnockbackPower * (collision.transform.position - transform.position).normalized;
            rb.AddForce(-playerKnockback, ForceMode2D.Impulse);

            TakeDamage(10);
        }
    }

    // DOESN'T WORK

    public void Dash()
    {
        if (Input.GetKey(KeyCode.Space) )//&& Time.time - timeLastDashed > 2f)
        {
            Debug.Log("Pressed");
            rb.AddForce(new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed).normalized);
            timeLastDashed = Time.time;
        }        
    }
}
