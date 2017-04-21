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

    public override void OnStartLocalPlayer()
    {
        GetComponent<SpriteRenderer>().material.color = Color.cyan;
    }
	
    void Awake()
    {
        if(SceneManager.GetActiveScene().name == "Game3")
        {

        }
        flashPanel = GameObject.FindWithTag("FlashPanel");
    }

	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer)
        {
            cam.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && hasBeer == true || Input.GetKeyDown(KeyCode.Joystick1Button3) && hasBeer)
        {
            gameObject.GetComponent<PlayerHealth>().currentHealth = 100;
            GameObject.Find("DrinkingSound").GetComponent<AudioSource>().Play();
            if (isLocalPlayer)
            {
                hasBeer = false;
                GameObject.FindWithTag("IconSlot").GetComponent<Image>().sprite = null;
                GameObject.FindWithTag("IconSlot").GetComponent<Image>().color = Color.black;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && hasBattery == true || Input.GetKeyDown(KeyCode.Joystick1Button2) && hasBattery == true)
        {
            StartCoroutine(FlashScreen());
            if (isLocalPlayer)
            {
                GameObject.FindWithTag("IconSlot2").GetComponent<Image>().sprite = null;
                GameObject.FindWithTag("IconSlot2").GetComponent<Image>().color = Color.black;
                hasBattery = false;
            }
        }



        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);


        Flip(horizontal);


    
    }

    IEnumerator FlashScreen()
    {
        flashPanel.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.95f);
        StartCoroutine(FreezeGhost());
        GameObject.Find("FlashSound").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.35f);
        flashPanel.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    IEnumerator FreezeGhost()
    {
        FindClosestGhost().gameObject.GetComponent<GhostFollowPlayer>().speed = 0;
        yield return new WaitForSeconds(2);
        FindClosestGhost().gameObject.GetComponent<GhostFollowPlayer>().speed = 2;
    }

    IEnumerator ReactivateAfterAPeriodOfTime(float time, GameObject gameObjectToReactivate)
    {

        yield return new WaitForSeconds(time);
        gameObjectToReactivate.SetActive(true);

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
                StartCoroutine(ReactivateAfterAPeriodOfTime(12, other.gameObject));
                if (isLocalPlayer)
                {
                    GameObject.FindWithTag("IconSlot").GetComponent<Image>().color = Color.white;
                    GameObject.FindWithTag("IconSlot").GetComponent<Image>().sprite = beerSprite;
                    hasBeer = true;
                }
            }
            
            if(other.CompareTag("DeathTrigger"))
            {
            GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().currentHealth = 0;
            }

            if(other.CompareTag("Battery"))
            {
                
                other.gameObject.SetActive(false);
                StartCoroutine(ReactivateAfterAPeriodOfTime(7, other.gameObject));
                if (isLocalPlayer)
                {
                    GameObject.FindWithTag("IconSlot2").GetComponent<Image>().color = Color.white;
                    GameObject.FindWithTag("IconSlot2").GetComponent<Image>().sprite = batterySprite;
                    hasBattery = true;
                }
            }
           
         }

        GameObject FindClosestGhost()
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Death");
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            return closest;
        }
}
