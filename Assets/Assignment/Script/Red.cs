using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Red : Character  // Derived from Character
{
    private bool isCrouching = false; // Boolean function to determine whether to crouch or not
    private Vector2 originalColliderSize; // Define the size of the original border (collider)
    private BoxCollider2D boxCollider;

    protected override void Start()
    {
        base.Start();
        boxCollider = GetComponent<BoxCollider2D>();
        originalColliderSize = boxCollider.size;
    }

    protected override void Update()
    {
        if(!isSelected) return;
        // Call the Update method of the base class to move horizontally
        base.Update();
        // Crouch when Ctrl is pressed, otherwise stand still.
        if (Input.GetKeyDown(KeyCode.LeftControl)) Crouch();
        else if (Input.GetKeyUp(KeyCode.LeftControl)) StandUp();
    }

    private void Crouch()
    {
        if (!isCrouching)
        {
            isCrouching = true;
            // If crouching is detected, reduce the size of the border (collider) and divide the character's height by "2" to indicate crouching.
            boxCollider.size = new Vector2(boxCollider.size.x, boxCollider.size.y / 2);
        }
    }

    private void StandUp()
    {
        if (isCrouching)
        {
            isCrouching = false;
            // Restore to original size
            boxCollider.size = originalColliderSize;
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.CompareTag("Steps")) canJump = true;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        //Calls OnTriggerEnter2D in the Character class
        base.OnTriggerEnter2D(collision);
        //Detect if player hit a red capsule, destroy the capsule if RedCharacter hit it (eat the capsule) and increase the score by 1 point.(score++)
        if (collision.gameObject.CompareTag("RedCapsule") && collision.gameObject.TryGetComponent<Capsule>(out Capsule capsule))
        {
            StartCoroutine(capsule.Eat());
            ScoreManager.IncreaseScore();
        }
    }
}