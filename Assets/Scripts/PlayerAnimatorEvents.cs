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

    void DamagedWeakEndEvent()
    {
        Player player = parent.GetComponent<Player>();
    }

    // 死亡アニメーションの終了時に呼ばれる処理
    void DeathEndEvent()
    {
        Destroy(parent);
    }
}
