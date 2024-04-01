using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 4.5f; //Define movement speed
    public float jump = 6f; //Defining Jump and Strength
    protected Rigidbody2D rb;
    protected bool canJump = true; //Boolean function for whether jumping is possible
    protected bool isSelected;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        if (!isSelected) return;
        //Horizontal movement of the character
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        // Jump when jumping is possible and the spacebar is pressed
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            canJump = false; // Can only jump once
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // Resume jumping when collision with an object is detected.
        if (collision.gameObject.CompareTag("Steps"))
        {
            canJump = true;
            Debug.Log(gameObject.name+" Can jump again");
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        // For child classes (capsule interactions - Different characters can only eat capsules of specific colors!!!!!!
    }

    public void Selected(bool value)
    {
        isSelected = value;
    }
}