using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask boxMask;

    //public Vector2 boxOffset = new Vector2 (1f, 0f);
    public Vector2 offsetRight = new Vector2 (1f,0f);
    public Vector2 offsetLeft = new Vector2 (-1f, 0f);
    public Vector2 offsetUp = new Vector2 (0f, 1f);
    public Vector2 offsetDown = new Vector2 (0f, -1f);

    private GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        //RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.right * Mathf.Sign(transform.localScale.x), distance, boxMask);
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, distance, boxMask);
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, distance, boxMask);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, distance, boxMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, distance, boxMask);


        //if (hit.collider != null && Input.GetKey(KeyCode.P))
        if ((hitUp.collider != null || hitDown.collider != null || hitLeft.collider != null || hitRight.collider != null) && Input.GetKey(KeyCode.P))
        {
            GameObject hitObject = null;
            Vector2 selectedOffset = Vector2.zero;
            //box = hit.collider.gameObject;

            if (hitUp.collider != null)
            {
                hitObject = hitUp.collider.gameObject;
                selectedOffset = offsetUp;
            }
            else if (hitDown.collider != null)
            {
                hitObject = hitDown.collider.gameObject;
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

            if (hitObject != null)
            {
                box = hitObject;
                var joint = box.GetComponent<FixedJoint2D>();
                if (joint == null)
                {
                    joint = box.AddComponent<FixedJoint2D>();
                }
                joint.enabled = true;
                joint.connectedBody = this.GetComponent<Rigidbody2D>();

                box.transform.position = transform.position + (Vector3)selectedOffset;
            }

            /*var joint = box.GetComponent<FixedJoint2D>();
            if (joint == null)
            {
                joint = box.AddComponent<FixedJoint2D>();
            }
            joint.enabled = true;
            joint.connectedBody = this.GetComponent<Rigidbody2D>();

            box.transform.position = transform.position + (Vector3)boxOffset;*/ 
        }
        else if (box != null && Input.GetKeyUp(KeyCode.P))
        {
        var joint = box.GetComponent<FixedJoint2D>();
        if (joint != null)
        {
            joint.enabled = false;
            box = null;
        }
        }

        /*if (box != null && box.GetComponent<FixedJoint2D>() != null)
        {
            box.transform.position = transform.position + (Vector3)boxOffset;
        }*/
    }
    

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
