using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

    private Rigidbody2D myRigidbody;
    public Sprite beerSprite;
    public Sprite batterySprite;
    private Animator myAnimator;
    public bool hasBeer = false;
    public bool hasBattery = false;
    public Camera cam;
    public GameObject flashPanel;

    [SerializeField]
    private float movementSpeed;

    private bool facingRight;

	// Use this for initialization
	void Start () {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        
	}
	
    void Awake()
    {
        flashPanel = GameObject.FindWithTag("FlashPanel");
    }

    void Update()
    {
        
    }

	// Update is called once per frame
	void FixedUpdate () {

        if (!isLocalPlayer)
        {
            cam.enabled = false;
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);

        Flip(horizontal);


        if (Input.GetKeyDown(KeyCode.E) && hasBeer == true)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().currentHealth = 100;
            hasBeer = false;
            GameObject.FindWithTag("IconSlot").GetComponent<Image>().sprite = null;
            GameObject.FindWithTag("IconSlot").GetComponent<Image>().color = Color.black;
        }

        if(Input.GetKeyDown(KeyCode.R) && hasBattery == true)
        {
            
            StartCoroutine(FlashScreen());
            GameObject.FindWithTag("IconSlot2").GetComponent<Image>().sprite = null;
            GameObject.FindWithTag("IconSlot2").GetComponent<Image>().color = Color.black;
            hasBattery = false;
        }
    }

    IEnumerator FlashScreen()
    {
        flashPanel.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.95f);
        yield return new WaitForSeconds(0.35f);
        flashPanel.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    private void HandleMovement(float horizontal) // Movement scripts
    { 
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);

        myAnimator.SetFloat("Speed", Mathf.Abs (horizontal));
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

        //Pick up Item Scripts
        void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.gameObject.CompareTag("Beer"))
            {
                other.gameObject.SetActive(false);
                GameObject.FindWithTag("IconSlot").GetComponent<Image>().color = Color.white;
                GameObject.FindWithTag("IconSlot").GetComponent<Image>().sprite = beerSprite;
                hasBeer = true;
            }
            
            if(other.CompareTag("DeathTrigger"))
            {
            GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().currentHealth = 0;
            }

            if(other.CompareTag("Battery"))
            {
                other.gameObject.SetActive(false);
                GameObject.FindWithTag("IconSlot2").GetComponent<Image>().color = Color.white;
                GameObject.FindWithTag("IconSlot2").GetComponent<Image>().sprite = batterySprite;
                hasBattery = true;
            }
           
         }

}
