using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class NewPlayerHealth : NetworkBehaviour
{

    public const int maxHealth = 100;
    [SerializeField]
    bool inLight = false;
    [SyncVar(hook = "OnChangeHealth")]
    public float currentHealth = maxHealth;

    public RectTransform healthBar;

    void Awake()
    {
        InvokeRepeating("TakeDamageOverTime", 0, 0.1f);
    }

    void Update()
    {
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(float amount)
    {
        if (!isServer)
            return;

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
            RpcRespawn();
            currentHealth = maxHealth;
        }
    }

    void TakeDamageOverTime()
    {
        if (!isServer)
            return;

        currentHealth -= 0.5f;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead");
            RpcRespawn();
            currentHealth = maxHealth;
        }
    }

    void OnChangeHealth(float health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
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

    void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Death" && !inLight)
        {
            TakeDamage(0.5f);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(0.2f);
        }

        if (collision.gameObject.tag == "Light")
        {
            return;
        }

        OnChangeHealth(currentHealth / maxHealth);
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
}