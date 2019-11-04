using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{


    [SerializeField] private GameObject target;

    NavMeshAgent agent;
    public Animator animator;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
        animator.SetFloat("Speed", agent.velocity.sqrMagnitude);

        // if (Input.GetKey(KeyCode.Space))
        // {
        //     animator.SetBool("Death", true);
        // }
        // else if (Input.GetKeyDown(KeyCode.H))
        // {
        //     animator.SetTrigger("Damage");
        // }
    }
    public void Damaged()
    {
        if (animator.GetBool("Damaged")) return;
        animator.SetBool("Damaged", true);

    }
}
