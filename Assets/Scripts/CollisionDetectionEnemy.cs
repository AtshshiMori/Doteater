using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionEnemy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.Damaged(10);
        }
    }
}