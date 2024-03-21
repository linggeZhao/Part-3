using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Transform[] parts;
    void Start()
    {
        StartCoroutine(BuildIn());
        for (int i = 0 ;i < parts.Length;i++)
        {
            parts[i].localScale = Vector3.zero;
        }
    }

    IEnumerator BuildIn()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            yield return StartCoroutine(ScaleIn(parts[i]));
        }
    }

    IEnumerator ScaleIn(Transform part)
    {
        part.localScale = Vector3.zero;
        float timer = 0f;
        while (timer < 1f)
        {
            part.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, timer);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
