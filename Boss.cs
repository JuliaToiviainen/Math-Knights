using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Boss : MonoBehaviour

{
    public int maxHealth = 100;
    int currentHealth = 100;
    public int playHealth = 100;
    public Transform player;
    public Animator animator;
    public Button button;
    public Text text;
    public Transform hitBox;
    public LayerMask playerLayer;
    public float attackRange = 1f;
    public HealthBar playerHealth;
    private int attackDamage = 10;

    public bool isFlipped = false;

    
    public void Start()
    {
        currentHealth = maxHealth;
        playerHealth.SetHealth(playHealth);
    }
    void HealthDown(int guess)
    {
        playHealth -= guess;
        playerHealth.SetHealth(playHealth);
    }

    public void takeDamage(int damage)
    {
        currentHealth-=damage;

        animator.SetTrigger("Hurt");

        if (currentHealth < 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("enemydies");

        animator.SetBool("IsDead", true);

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Win();
    }

    void Win()
    {
        Vector3 pos = button.transform.position;
        pos.x = 0;
        button.transform.position = pos;
        pos = text.transform.position;
        pos.x = 0;
        text.transform.position = pos;

    }

    public void Continue()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void playerDamage(int dam)
    {

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(hitBox.position, attackRange, playerLayer);

        foreach (Collider2D pers in hitPlayer)
        {
            pers.GetComponent<PlayerCombat>().currentHealth -= dam;
            pers.GetComponent<Animator>().SetTrigger("attTrig");
            HealthDown(attackDamage);

        }
        

    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    
}
