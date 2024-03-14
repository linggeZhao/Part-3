using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tou : Villager
{
    public GameObject knifePrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public float delay = 0.5f;
    private Vector2 targetPosition;
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

    protected override void Attack()
    {
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        base.Attack();
        Invoke("SpawnKnife", delay);
    }

    void SpawnKnife()
    {
        Instantiate(knifePrefab, spawnPoint1.position, spawnPoint1.rotation);
        Instantiate(knifePrefab, spawnPoint2.position, spawnPoint2.rotation);
    }
}
