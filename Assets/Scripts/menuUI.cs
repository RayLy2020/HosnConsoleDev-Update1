﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuUI : MonoBehaviour {

    public int IndexNum;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeScene() 
    {
        SceneManager.LoadScene(IndexNum, LoadSceneMode.Single);
    }
    public void ChangeSceneString(string name)
    {
        SceneManager.LoadScene(name);
    }
}
