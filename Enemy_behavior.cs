using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behavior : MonoBehaviour
{
    #region Public variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator animator;
    private float distance;
    private bool inRange;
    private bool attackMode;
    private bool cooling;
    private float intTimer;
    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        intTimer = timer;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);
            RaycastDebugger();
        }
        if(hit.collider != null)
        {
            EnemyLogic();
        }
        else if(hit.collider == null)
        {
            inRange = false;
        }
        if (inRange == false)
        {
            animator.SetBool("canWalk", false);
            StopAttack();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if(distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        if (cooling)
        {
            CoolDown();
            animator.SetBool("Attack", false);
        }
    }
    void Move()
    {
        animator.SetBool("canWalk", true);
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("enemy_attack1"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        animator.SetBool("canWalk", false);
        animator.SetBool("Attack", true);
    }
    void CoolDown()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
    void StopAttack()
    {
        cooling = false;
        attackMode= false;
        animator.SetBool("Attack", false );
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }
    }
    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if(attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }
    public void TriggerCooling()
    {
        cooling=true;
    }
}
