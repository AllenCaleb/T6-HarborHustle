using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PushCrates : MonoBehaviour
{
    [SerializeField] private Transform raycastPoint;
    public float distance = 1f;
    public LayerMask boxMask;

    public Vector2 offsetRight = new Vector2(1f, 0f);
    public Vector2 offsetLeft = new Vector2(-1f, 0f);
    public Vector2 offsetUp = new Vector2(0f, 1f);
    public Vector2 offsetDown = new Vector2(0f, -1f);

    private GameObject crate;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        //RaycastHit2D hit = Physics2D.Raycast(raycastPoint.position, Vector2.right * raycastPoint.localScale.x, distance, boxMask);
        RaycastHit2D hitUp = Physics2D.Raycast(raycastPoint.position, Vector2.up * raycastPoint.localScale.y, distance, boxMask);
        RaycastHit2D hitDown = Physics2D.Raycast(raycastPoint.position, Vector2.down * raycastPoint.localScale.y, distance, boxMask);
        RaycastHit2D hitRight = Physics2D.Raycast(raycastPoint.position, Vector2.right * raycastPoint.localScale.x, distance, boxMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(raycastPoint.position, Vector2.left * raycastPoint.localScale.x, distance, boxMask);

        // Add code below back if this doesn't work
        /*if (hit.collider != null && hit.collider.gameObject.tag == "Crate" && Input.GetKeyDown(KeyCode.K))
        {
            crate = hit.collider.gameObject;

            crate.GetComponent<FixedJoint2D>().enabled = true;
            crate.GetComponent<cratepull> ().enabled = true;
            crate.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if(Input.GetKeyUp(KeyCode.K)) 
        {
            crate.GetComponent<FixedJoint2D>().enabled = false;
            crate.GetComponent<cratepull>().enabled = false;
        }*/

        if ((hitUp.collider != null || hitDown.collider != null || hitLeft.collider != null || hitRight.collider != null) && Input.GetKey(KeyCode.P))
        {
            animator.SetBool("IsPushing", true);

            GameObject hitObject = null;
            Vector2 selectedOffset = Vector2.zero;

            if (hitUp.collider != null)
            {
                hitObject = hitUp.collider.gameObject;
                selectedOffset = offsetUp;
            }
            else if (hitDown.collider != null)
            {
                hitObject= hitDown.collider.gameObject;
                selectedOffset = offsetDown;
            }
            else if (hitLeft.collider != null)
            {
                hitObject = hitLeft.collider.gameObject;
                selectedOffset = offsetLeft;
            }
            else if (hitRight.collider != null)
            {
                hitObject = hitRight.collider.gameObject;
                selectedOffset = offsetRight;
            }

            if (hitObject != null && hitObject.CompareTag("Crate"))
            {
                crate = hitObject;
                var joint = crate.GetComponent<FixedJoint2D>();
                if (joint == null)
                {
                    joint = crate.AddComponent<FixedJoint2D>();
                }
                joint.enabled = true;
                joint.connectedBody = this.GetComponent<Rigidbody2D>();

                crate.transform.position = transform.position + (Vector3)selectedOffset;
            }
        }
        else if (crate != null && Input.GetKeyUp(KeyCode.P))
        {
            animator.SetBool("IsPushing", false);
            var joint = crate.GetComponent<FixedJoint2D>();
            if (joint != null)
            {
                joint.enabled = false;
                crate = null;
            }
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
         
        Gizmos.DrawLine(raycastPoint.position, (Vector2)raycastPoint.position + Vector2.right * raycastPoint.localScale.x * distance);
    }*/

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.left * transform.localScale.x * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.up * transform.localScale.x * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.down * transform.localScale.x * distance);
    }
}
