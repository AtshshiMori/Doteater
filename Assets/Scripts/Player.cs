using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject cam;
    public float moveSpeed = 5f;
    public float rotationSpeed = 360f;

    [SerializeField] private float hp = 1.0f;
    // public GameObject bulletPrefab;
    // public float speed = 1.0f;
    private CharacterController characterController;
    private Animator animator;
    private GameObject child;

    // コライダー
    private Collider handCollider;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        child = transform.Find("unitychan").gameObject;

        handCollider = GameObject.Find("Character1_LeftHand").GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jab"))
        {
            handCollider.enabled = false;
        }
        else
        {
            return;
        }

        // Ratate
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0) * direction;
        if (direction.sqrMagnitude > 0.01f)
        {

            Vector3 forward = Vector3.Slerp(
                                  transform.forward,
                                  direction,
                                  rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
                              );
            transform.LookAt(transform.position + forward);
        }


        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jab"))
        {
            // Move
            characterController.Move(direction * moveSpeed * Time.deltaTime);

            // Attack
            if (Input.GetKeyDown(KeyCode.Space))
            {
                handCollider.enabled = true;
                animator.SetTrigger("Jab");
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                animator.SetTrigger("DamagedWeak");
            }
        }
        animator.SetFloat("Speed", characterController.velocity.magnitude);
        characterController.Move(new Vector3(0, Physics.gravity.y * Time.deltaTime * Time.deltaTime, 0)); // 重力を与える



        // アニメーションでこ要素の位置がズレるのを修正
        child.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        child.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);



        // shoot
        // if (Input.GetKeyDown(KeyCode.Space)) Shoot();

        // if (GameObject.FindGameObjectsWithTag("Dot").Length == 0)
        // {
        //     SceneManager.LoadScene("Win");
        // }
    }

    public void Damaged(int attackPoint)
    {
        if (animator.GetBool("DamagedWeak") || animator.GetBool("Death")) return;

        hp -= attackPoint;

        if (hp <= 0)
        {
            animator.SetBool("Death", true);
        }
        else
        {
            animator.SetBool("DamagedWeak", true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dot")
        {
            Dot dot = other.GetComponent<Dot>();
            dot.getDot();
        }
        else if (other.tag == "Enemy")
        {
            //SceneManager.LoadScene("Lose");
        }
    }



    // void Shoot()
    // {
    //     GameObject bullet = Instantiate(bulletPrefab) as GameObject;
    //     Vector3 force = this.transform.forward * speed;
    //     bullet.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    //     bullet.transform.position = this.transform.position + new Vector3(0.0f, 0.5f, 0.0f);
    // }
}
