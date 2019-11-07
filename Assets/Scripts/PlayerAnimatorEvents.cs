using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorEvents : MonoBehaviour
{
    [SerializeField] private GameObject waterAttackParticle = null;


    GameObject tmp_waterAttackParticle;
    Animator animator;
    GameObject parent;
    Collider handCollider;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        parent = transform.parent.gameObject;
        handCollider = GameObject.Find("Character1_LeftHand").GetComponent<SphereCollider>();
    }

    // ダメージアニメーションの終了時に呼ばれる処理
    void DamagedWeakEndEvent()
    {
        animator.SetBool("DamagedWeak", false);
    }

    // 死亡アニメーションの終了時に呼ばれる処理
    void DeathEndEvent()
    {
        Destroy(parent);
    }

    // ジャブ攻撃のアニメーションの開始時に呼ばれる処理
    void JabStartEvent()
    {
        handCollider.enabled = true;
    }

    // ジャブ攻撃のアニメーションの終了時に呼ばれる処理
    void JabEndEvent()
    {
        handCollider.enabled = false;
        animator.SetBool("Jab", false);
    }


    // 水攻撃のアニメーションの開始時に呼ばれる処理
    void WaterAttackStartEvent()
    {
        Vector3 pos = transform.position + transform.rotation * new Vector3(0.0f, 1.0f, 1.0f);
        Quaternion rot = transform.rotation * Quaternion.Euler(-90, 0, 0);
        tmp_waterAttackParticle = Instantiate(waterAttackParticle, pos, rot);
    }
    // 水攻撃のアニメーションの終了時に呼ばれる処理
    void WaterAttackEndEvent()
    {
        Destroy(tmp_waterAttackParticle);
        animator.SetBool("WaterAttack", false);
    }
}
