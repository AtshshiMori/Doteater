using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 10.0f;
    [SerializeField] private GameObject getParticle = null;

    public Atoms.Atom type = Atoms.Atom.H;

    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed, 0));
    }

    public void getDot()
    {
        GameObject particle = GameObject.Instantiate(getParticle, this.transform.position, getParticle.transform.rotation);
        Destroy(this.gameObject);
        Destroy(particle, getParticle.GetComponent<ParticleSystem>().main.duration);
    }

}
