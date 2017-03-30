using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

	Camera cam;
	World world;
	float movement = 10f;
	Vector3 move;

	// Use this for initialization
	void Start () {

		world = FindObjectOfType<World>();
		 cam = this.GetComponent<Camera> ();
		this.transform.position = new Vector3 (world.height/2, world.width/2,-10f);
		cam.orthographicSize = 80f;
	}
	
	// Update is called once per frame
	void Update () {
		move = new Vector3 (Input.GetAxisRaw("Horizontal") * movement * Time.deltaTime, Input.GetAxisRaw("Vertical") * movement * Time.deltaTime,-10f);
		transform.Translate (move);
		transform.position = new Vector3 (Mathf.Clamp(transform.position.x,-100, 200),Mathf.Clamp(transform.position.y,-100, 200),-10f);

	}
}
