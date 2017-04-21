using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    NetworkManager netman;
    public Text pressStart;
    public GameObject[] gameObjectsToHide;
	// Use this for initialization
	void Start () {
        netman = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        for(int i = 0; i < gameObjectsToHide.Length; i++)
        {
            gameObjectsToHide[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Destroy(pressStart);
            netman.StartHost();
            for(int i = 0; i < gameObjectsToHide.Length; i++)
            {
                gameObjectsToHide[i].SetActive(true);
            }
        }
	}
}
