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
        // Jabのコライダーを更新
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) handCollider.enabled = false;

        // NabMeshの設定
        agent.destination = target.transform.position;
        animator.SetFloat("Speed", agent.velocity.sqrMagnitude);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") ||
           animator.GetCurrentAnimatorStateInfo(0).IsName("Damaged") ||
           animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            agent.velocity = Vector3.zero;
        }

        // 一定距離まで近づいたら攻撃
        if (Vector3.Distance(target.transform.position, transform.position) < attackDistance)
        {
            animator.SetTrigger("Attack");
            handCollider.enabled = true;
        }

    }
    public void Damaged(float attackPoint)
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
