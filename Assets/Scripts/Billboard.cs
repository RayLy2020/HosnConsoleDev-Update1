using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{
    public Transform transformToLookAt;
    private bool facingRight;

    void Awake()
    {
        facingRight = true;
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Flip(horizontal);
        /*
        if(Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.LookAt(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y,-Camera.main.transform.position.z));
        }
        else
        {
            transform.LookAt(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        }
         */

    }

    private void Flip(float horizontal) // Character flip handling
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}