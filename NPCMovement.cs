using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    public Sprite germain;
    public SpriteRenderer render;
    private bool moveNow = false;
    public Animator animator;

    private Vector3 holding;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform child;

    [SerializeField]
    private Transform child2;
    // Start is called before the first frame update

    void Start()
    {
        animator = GetComponent<Animator>();
        holding = Vector3.zero;
    }

    public void MoveInto()
    {
        
        holding = (child2.localPosition - child.position).normalized;
        move();
    }

    public void move()
    {
        moveNow = true;
        animator.Play("SlideInIdle.Slide", 0, 0.25f);
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveNow == true)
        {
            if (child.position.x <= child2.position.x)
            {
                child.position += holding * speed * Time.deltaTime;
            }
        }
    }
}
