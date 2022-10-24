using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }*/
        if (Input.GetKey(KeyCode.Return))
        {
            WrongGuess(1);
        }

        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
    }

    void WrongGuess(int guess)
    {
        currentHealth -= guess;
        healthBar.SetHealth(currentHealth);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }
}

