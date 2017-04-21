using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{

    public Vector3 jump;
    public float jumpForce = 20.0f;
    public bool isGrounded;
    Rigidbody2D rb;

    void Awake()
    {

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 20.0f, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded || Input.GetKeyDown(KeyCode.Joystick1Button0) && isGrounded)
        {
            //Jump Script 
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            GameObject.Find("JumpSound").GetComponent<AudioSource>().Play();
            isGrounded = false;
        }
    }
}