using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class FinalDoorScript : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.UpArrow) || other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            //SceneManager.LoadScene("Win");
            NetworkManager.singleton.ServerChangeScene("Win");
        }
    }
}
