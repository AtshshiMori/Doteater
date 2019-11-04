using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorEvents : MonoBehaviour
{
    Animator animator;
    GameObject parent;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        parent = transform.parent.gameObject;
    }
    // ダメージアニメーションの終了時に呼ばれる処理
    void DamagedWeakEndEvent()
    {
        animator.SetBool("DamagedWeak", false);
    }

    void DeathEndEvent()
    {
        Destroy(parent);
    }
}
