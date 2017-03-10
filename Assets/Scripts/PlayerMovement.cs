using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D myRigidbody;

    private Animator myAnimator;

    [SerializeField]
    private float movementSpeed;

    private bool facingRight;

	// Use this for initialization
	void Start () {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);

        Flip(horizontal);
	}

    private void HandleMovement(float horizontal)
    { 
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);

        myAnimator.SetFloat("Speed", Mathf.Abs (horizontal));
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Door")
        {
            Debug.Log("WORKKING");
        }

        if (col.gameObject.tag == "Door" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.transform.localPosition = new Vector3(-19f, -10.55f, 0f);
        }

        if (col.gameObject.tag == "Door2" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.transform.localPosition = new Vector3(-8.85f, -6.38f, 0f);
        }

        if (col.gameObject.tag == "Door3" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.transform.localPosition = new Vector3(-13f, -10.55f, 0f);
        }

        if (col.gameObject.tag == "Door4" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.transform.localPosition = new Vector3(-3.08f, -6.38f, 0f);
        }

        if (col.gameObject.tag == "Door5" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.transform.localPosition = new Vector3(-7f, -10.55f, 0f);
        }

        if (col.gameObject.tag == "Door6" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.transform.localPosition = new Vector3(5.52f, -6.38f, 0f);
        }

        if (col.gameObject.tag == "Door7" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.transform.localPosition = new Vector3(4.67f, -2.47f, 0f);
        }

        if (col.gameObject.tag == "Door8" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.transform.localPosition = new Vector3(2.41f, -6.39f, 0f);
        }

        /*if (col.gameObject.tag == "Door3" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.transform.localPosition = new Vector3(-13f, -10.55f, 0f);
        }
        */
        
    }

}
