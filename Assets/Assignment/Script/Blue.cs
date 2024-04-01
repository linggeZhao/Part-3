using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;

public class Blue : Character  // Derived from Character
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset the jump function when contact with the ground is detected.
        if (collision.gameObject.CompareTag("Steps"))
        {
            canJump = true;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        //Detect if player hit a Blue capsule, destroy the capsule if BlueCharacter hit it (eat the capsule) and increase the score by 1 point.(score++)
        if (collision.gameObject.CompareTag("BlueCapsule") && collision.gameObject.TryGetComponent<Capsule>(out Capsule capsule))
        {
            StartCoroutine(capsule.Eat());
            ScoreManager.IncreaseScore();
        }
    }
}