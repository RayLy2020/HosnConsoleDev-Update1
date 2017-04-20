<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public GameObject platform;

    public float moveSpeed;

    private Transform currentPosition;

    public Transform[] points;

    public int pointSelect;

    // Use this for initialization
    void Start()
    {
        currentPosition = points[pointSelect];
    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPosition.position, Time.deltaTime * moveSpeed);

=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public GameObject platform;

    public float moveSpeed;

    private Transform currentPosition;

    public Transform[] points;

    public int pointSelect;

	// Use this for initialization
	void Start () {
        currentPosition = points[pointSelect];
	}
	
	// Update is called once per frame
	void Update () {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPosition.position, Time.deltaTime * moveSpeed);

>>>>>>> ade574ed77c664f87af85e8ffb53393106fc6a02
        if (platform.transform.position == currentPosition.position)
        {
            pointSelect++;

            if (pointSelect == points.Length)
            {
                pointSelect = 0;
            }
            currentPosition = points[pointSelect];
<<<<<<< HEAD
        }
    }
}
=======
        }
	}
}
>>>>>>> ade574ed77c664f87af85e8ffb53393106fc6a02
