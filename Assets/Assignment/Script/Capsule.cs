using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    public AnimationCurve eating;
    public IEnumerator Eat()
    {
        float timer = 0;
        Vector3 position=transform.position;
        Destroy(GetComponent<Collider2D>());
        while (timer<1)
        {
            timer+= Time.deltaTime;
            float interporlation = eating.Evaluate(timer);
            transform.position = Vector3.Lerp(position, position + Vector3.up * 2, interporlation);
            yield return null;
        }
        Destroy(gameObject);
    }
}
