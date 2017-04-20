using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraNetwork : NetworkBehaviour {

    Camera viewCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        cameraFollow();

	}

    void cameraFollow()
    {
        float charPosX = transform.position.x;
        float charPosZ = transform.position.z;
        float cameraOffset = 18.0f;

        viewCamera.transform.position = new Vector3(charPosX, cameraOffset, charPosZ);

    }
}
