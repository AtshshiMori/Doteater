using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionPlayer : MonoBehaviour
{
    [SerializeField] private float ap = 10; // Attack Point
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.Damaged(ap);
        }
    }
}