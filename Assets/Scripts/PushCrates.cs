using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PushCrates : MonoBehaviour
{

    public float distance = 1f;
    public LayerMask boxMask;

    GameObject crate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "Crate" && Input.GetKeyDown(KeyCode.K))
        {
            crate = hit.collider.gameObject;

            crate.GetComponent<FixedJoint2D>().enabled = true;
            crate.GetComponent<cratepull> ().enabled = true;
            crate.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if(Input.GetKeyUp(KeyCode.K)) 
        {
            crate.GetComponent<FixedJoint2D> ().enabled = false;
            crate.GetComponent<cratepull>().enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
         
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
