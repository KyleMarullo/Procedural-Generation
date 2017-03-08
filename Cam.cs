using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0f, Input.GetAxisRaw ("Vertical")) * 3;

	}
}
