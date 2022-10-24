using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 5f;
    public float attackRate = 2f;
    float nextAttacktime = 0f;
    public LayerMask enemyLayers;
    public int maxHealth = 10;
    public int currentHealth = 100;
    public int enHealth = 100;
    public HealthBar healthBar;
    public HealthBar enemyHealth;
    private int attackDamage = 20;
    public Collider2D enemyColliderBox;
    public Collider2D playerColliderBox;
    protected ContactFilter2D contactFilter;
    private EnchantLevel1 enchantVal;
    public Transform enemyDis;

    public Button button;
    public Text text;


    void Start()
    {
        Debug.Log("start");
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttacktime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttacktime = Time.time + 1f / attackRate;
            }
        }
        if (currentHealth <= 0)
        {
            Die();
        }
        
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Boss>().takeDamage(attackDamage);
            HealthDown(attackDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    void HealthDown(int guess)
    {
        enHealth -= guess;
        enemyHealth.SetHealth(enHealth);
    }

    void Die()
    {
        
            Debug.Log("youdied");

            animator.SetBool("IsDead", true);

            this.enabled = false;
            GetComponent<Collider2D>().enabled = false;
        //GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<PlayerMovment>().enabled = false;
        //enemyDis.GetComponent<Transform>().enabled = false;
        //GetComponent<Boss>().hitBox<Collider2D>().enabled = false;
        Lose();


    }

    void Lose()
    {
        Vector3 pos = button.transform.position;
        pos.x = 0;
        button.transform.position = pos;
        pos = text.transform.position;
        pos.x = 0;
        text.transform.position = pos;
    }

    public void TryAgain()
    {
        //SceneManager.LoadScene("EnchantMenu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
