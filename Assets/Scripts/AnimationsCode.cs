using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public bool isNearCrate;
    public bool isPushingUp;
    public bool isPushingLeft;
    public bool isPushingDown;
    public bool isPushingRight;
    
    public Animator animator;
    void Start()
    {

    }

    private void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (isNearCrate && Input.GetKeyDown(KeyCode.W))
        {

            animator.SetBool("IsPushingUp", true);
            isPushingUp = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {

            animator.SetBool("IsPushingUp", false);
            isPushingUp = false;
        }

        if (!isPushingUp && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsWalkingUp", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("IsWalkingUp", false);
        }

        if (isNearCrate && Input.GetKeyDown(KeyCode.A))
        {

            animator.SetBool("IsPushingLeft", true);
            isPushingLeft = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {

            animator.SetBool("IsPushingLeft", false);
            isPushingLeft = false;
        }

        if (!isPushingLeft && Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsWalkingLeft", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("IsWalkingLeft", false);
        }

        if (isNearCrate && Input.GetKeyDown(KeyCode.S))
        {

            animator.SetBool("IsPushingDown", true);
            isPushingDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {

            animator.SetBool("IsPushingDown", false);
            isPushingDown = false;
        }

        if (!isPushingDown && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsWalkingDown", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("IsWalkingDown", false);
        }

        if (isNearCrate && Input.GetKeyDown(KeyCode.D))
        {

            animator.SetBool("IsPushingRight", true);
            isPushingRight = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {

            animator.SetBool("IsPushingRight", false);
            isPushingRight = false;
        }

        if (!isPushingRight && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsWalkingRight", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("IsWalkingRight", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crate"))
        {
            isNearCrate = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crate"))
        {
            isNearCrate = true;
        }
    }

}