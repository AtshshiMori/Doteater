using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionPlayer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.Damaged(10);
        }
    }
}