// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Bullet : MonoBehaviour
// {

//     // Use this for initialization
//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }

//     void OnCollisionEnter(Collision other)
//     {
//         Debug.Log(other.gameObject.tag);
//         if (other.gameObject.tag != "Player")
//         {
//             Destroy(this.gameObject);
//         }
//     }
//     void OnTriggerEnter(Collider other)
//     {
//         Debug.Log(other.gameObject.name);
//         if (other.tag == "Enemy")
//         {
//             Rigidbody rg_enemy = other.GetComponent<Rigidbody>();
//             Rigidbody rg_bullet = this.GetComponent<Rigidbody>();
//             rg_enemy.AddForce(rg_bullet.velocity.normalized, ForceMode.Impulse);

//             Enemy enemy = other.gameObject.GetComponent<Enemy>();
//             enemy.damaged(10);
//         }

//         if (other.tag != "Player")
//         {
//             Destroy(this.gameObject);
//         }
//     }
// }
