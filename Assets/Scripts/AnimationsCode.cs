using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;

    public Animator animator;
    void Start()
    {

    }

    private void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("IsWalkingUp", true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("IsWalkingLeft", true);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("IsWalkingDown", true);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("IsWalkingRight", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("IsWalkingUp", false);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("IsWalkingLeft", false);
        }


        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("IsWalkingDown", false);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("IsWalkingRight", false);
        }



    }
}