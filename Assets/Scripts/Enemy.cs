using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{


    [SerializeField] GameObject target;
    [SerializeField] private GameObject debugSphere;

    NavMeshAgent agent;
    Animator animator;
    private GameObject ds;
    private Vector3 steeringTarget;
    private bool isCorner = true;
    private float speed = 0.0f; // NavMeshAgentのspeedを保持するための変数

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        speed = agent.speed;     // 初期値の保持
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
        animator.SetFloat("Speed", agent.velocity.sqrMagnitude);

        agent.velocity = (agent.steeringTarget - transform.position).normalized * agent.speed;
        transform.forward = agent.steeringTarget - transform.position;

        // 解決策2 曲がり角でスピードを落とす
        // if (Vector3.Distance(agent.steeringTarget, transform.position) < 2.0f)
        // {
        //     agent.speed = 1.0f;
        // }
        // else
        // {
        //     agent.speed = speed;
        // }

        //     Destroy(ds);
        //     ds = GameObject.Instantiate(debugSphere, agent.steeringTarget, Quaternion.identity);
    }
}
