using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    // Start is called before the first frame update
    public AIPath aiPath;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        //horizMove = aiPath.desiredVelocity.x;
        animator.SetFloat("Speed", 0.02f);
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-3.7f, 3.7f, 3.7f);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f) 
        {
            transform.localScale = new Vector3(3.7f, 3.7f, 3.7f);
        }
    }
}
