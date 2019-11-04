using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{


    [SerializeField] private GameObject target = null;

    [SerializeField] private float hp = 1.0f;
    [SerializeField] private float attackDistance = 2.0f;

    NavMeshAgent agent;
    public Animator animator;

    // collider
    Collider handCollider;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        handCollider = GameObject.Find("R_IK_A").GetComponent<SphereCollider>();
        handCollider.enabled = false;
    }

    void Update()
    {
        agent.destination = target.transform.position;
        animator.SetFloat("Speed", agent.velocity.sqrMagnitude);

        // 一定距離まで近づいたら攻撃
        if (Vector3.Distance(target.transform.position, transform.position) < attackDistance)
        {
            animator.SetBool("Attack", true);
            handCollider.enabled = true;
        }
        // if (Input.GetKey(KeyCode.Space))
        // {
        //     animator.SetBool("Death", true);
        // }
        // else if (Input.GetKeyDown(KeyCode.H))
        // {
        //     animator.SetTrigger("Damage");
        // }
    }
    public void Damaged(int attackPoint)
    {
        if (animator.GetBool("Damaged") || animator.GetBool("Death")) return;

        hp -= attackPoint;

        if (hp <= 0)
        {
            animator.SetBool("Death", true);
        }
        else
        {
            animator.SetBool("Damaged", true);
        }
    }
}
