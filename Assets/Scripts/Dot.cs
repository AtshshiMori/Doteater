using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    private const string key_isGot = "IsGot";

    [SerializeField] private float rotateSpeed = 10.0f;
    [SerializeField] private GameObject getParticle = null;

    public Atoms.Atom type = Atoms.Atom.H;
    Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed, 0));
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Deth"))
        {
            Destroy(this.gameObject);
        }
    }

    public void getDot()
    {
        animator.SetBool(key_isGot, true);
        GameObject.Instantiate(getParticle, this.transform.position, getParticle.transform.rotation);
        // Destroy(this.gameObject);
    }

}
