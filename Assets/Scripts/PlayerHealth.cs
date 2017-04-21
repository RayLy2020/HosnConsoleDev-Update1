using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour {
    
    public const float maxHealth = 100f;
    [SyncVar(hook= "setHealthBar")]
    public float currentHealth = maxHealth;
    public RectTransform healthBar;
    
    [SerializeField] bool inLight = false;

    void Awake()
    {
        currentHealth = maxHealth;

        InvokeRepeating("decreaseHealth", 0.0f, 0.1f);
        //healthBar = GameObject.FindWithTag("HealthBar");
    }
	// Use this for initialization
	void Start () {

	
	}

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            // move back to zero location
            transform.position = Vector3.zero;
        }
    }
	
	// Update is called once per frame
	void Update () {
        Healthy(0);
	}

    void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Death" && !inLight)
        {
            currentHealth -= 0.5f;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            currentHealth -= 0.2f;
        }

        if (collision.gameObject.tag == "Light")
        {
            return;
            //currentHealth = currentHealth;
        }

        float calculateHealth = currentHealth / maxHealth;
        setHealthBar(calculateHealth);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            inLight = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            inLight = false;
        }
    }

    public void setHealthBar(float currentHealth)
    {
            //healthBar.transform.localScale = new Vector3(-playerHealth, healthBar.transform.localScale.y, transform.localScale.z);
            healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }
    
    void decreaseHealth()
    {
        if (!isServer)
        {
            return;
        }

            if (inLight == false)
            {
                currentHealth -= 0.2f;
                float calculateHealth = currentHealth / maxHealth;
                //setHealthBar(calculateHealth);
            }
        
    }
    

    void Healthy(int adj)
    {
        currentHealth += adj;

        if (currentHealth < 0f)
        {
            currentHealth = 0f;
            GameObject.Find("DeathScream").GetComponent<AudioSource>().Play();
            RpcRespawn();
            currentHealth = maxHealth;
            //SceneManager.LoadScene("GameOver");
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        /*
        if (maxHealth < 1f)
        {
            maxHealth = 1f;
        }
        */
    }

}
