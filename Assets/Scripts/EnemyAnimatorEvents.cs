using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorEvents : MonoBehaviour
{
    Animator animator;
    GameObject parent;
    Collider handCollider;
    GateManager gateManager;


    void Start()
    {
        animator = this.GetComponent<Animator>();
        parent = transform.parent.gameObject;
        handCollider = GameObject.Find("R_IK_A").GetComponent<SphereCollider>();
        gateManager = GameObject.Find("GateManager").GetComponent<GateManager>();
    }

    // 攻撃終了時に呼ばれる処理
    void AttackEndEvent()
    {
        handCollider.enabled = false;
    }

    // ダメージアニメーションの終了時に呼ばれる処理
    void DamagedEndEvent()
    {
        animator.SetBool("Damaged", false);
    }

    void DeathEndEvent()
    {
        Destroy(parent);
    }
}
