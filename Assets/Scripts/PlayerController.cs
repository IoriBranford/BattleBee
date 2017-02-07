using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 inputDir = new Vector2 (Input.GetAxisRaw("Horizontal"), 0);
		var rigidBody = GetComponent<Rigidbody2D> ();
		rigidBody.velocity = inputDir * speed;
	}
}
