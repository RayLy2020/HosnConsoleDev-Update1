using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

    public GameObject text;
	// Use this for initialization
	void Start () {
        text = GameObject.Find("Avoid The Ghost");
        StartCoroutine(HideAfter());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator HideAfter()
    {
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }
}
