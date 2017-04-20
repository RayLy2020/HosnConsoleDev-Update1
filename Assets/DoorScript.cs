using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DoorScript : MonoBehaviour {

    public Transform teleportLocation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.UpArrow))
        {
            other.transform.position = teleportLocation.transform.position;
            //gameObject.AddComponent<NetworkStartPosition>();
            GameObject.FindWithTag("Death").transform.position = teleportLocation.transform.position;
        }
    }

}
