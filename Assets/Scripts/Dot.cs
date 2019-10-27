using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    private const string key_isGot = "IsGot";

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Deth"))
        {
            Destroy(this.gameObject);
        }
    }

    public void getDot()
    {
        animator.SetBool(key_isGot, true);
    }

}
