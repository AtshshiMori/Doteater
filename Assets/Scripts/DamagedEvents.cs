using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedEvents : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    // ダメージアニメーションの終了時に呼ばれる処理
    void DamagedEndEvent()
    {
        animator.SetBool("Damaged", false);
    }
}
