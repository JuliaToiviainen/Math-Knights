using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementMap : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 move;
    

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
    }

    //movement
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }
}
