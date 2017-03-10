using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    
    public float maxHealth = 100f;
    public float currentHealth = 0f;
    public GameObject healthBar;

    [SerializeField] bool inLight = true;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        
        InvokeRepeating("decreaseHealth", 0.0f, 0.1f);
	
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
            currentHealth = currentHealth;


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

    public void setHealthBar(float playerHealth)
    { 
      healthBar.transform.localScale = new Vector3(playerHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    void decreaseHealth()
    {
        if(inLight == false)
        {
            currentHealth -= 0.2f;
            float calculateHealth = currentHealth / maxHealth;
            setHealthBar(calculateHealth);
        }
    }

    void Healthy(int adj)
    {
        currentHealth += adj;

        if (currentHealth < 0f)
        {
            currentHealth = 0f;
            Application.LoadLevel("GameOver");
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (maxHealth < 1f)
        {
            maxHealth = 1f;
        }

    }

}
