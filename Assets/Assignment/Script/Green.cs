using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Green : Character  // Derived from Character
{
    private int jumpCount = 0; // Jump counter
    private int maxJumpCount = 2; // Maximum number of jumps is 2 - two jumps

    protected override void Update()
    {
        if (!isSelected) return;
        base.Update(); // Call the Update method of the base class to move horizontally
        // Double jump (can press space up to twice - detects the number of presses, maximum 2)
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            jumpCount++; // Increase the number of jumps
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset jump function when collision with an object is detected
        if (collision.gameObject.CompareTag("Steps"))
        {
            jumpCount = 0;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        //Detect if player hit a green capsule, destroy the capsule if GreenCharacter hit it (eat the capsule) and increase the score by 1 point.(score++)
        if (collision.gameObject.CompareTag("GreenCapsule") && collision.gameObject.TryGetComponent<Capsule>(out Capsule capsule))
        {
            StartCoroutine(capsule.Eat());
            ScoreManager.IncreaseScore();
        }
    }
}