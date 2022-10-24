using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyCombat : MonoBehaviour
{

    public Animator animator;
    public bool hurt;
    public int MaxHealth = 100;
    int currentHealth;
    public AIPath aiPath;

    #region Public variables
    public Transform raycast;
    public LayerMask raycastMask;
    public float raycastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private float distance;
    private bool inRange;
    private bool attackMode;
    private bool cooling;
    private float intTimer;
    #endregion

    // Update is called once per frame
    void Start()
    {
        currentHealth = MaxHealth;
    }
    public void Takedamage(int damage)
    {

        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        //Debug.Log("Enemy died");

        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        aiPath.enabled = false;


    }
    void Awake()
    {
        intTimer = timer;
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Attack", true);
            animator.SetFloat("Speed", 0f);
        }
    }
      
}
