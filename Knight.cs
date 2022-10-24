using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 move; 

    public int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;

    //public GameOver GameOver;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    //input
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            WrongGuess(10);
            animator.SetTrigger("Attack1");
        }

        //arrow keys gives value between -1 to 1
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

    }

    void WrongGuess(int guess)
    {
        currentHealth -= guess;
        healthBar.SetHealth(currentHealth);
    }

    //movement
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }

  //  IEnumerable ExampleCoroutine()
  //  {

  //  }
}
