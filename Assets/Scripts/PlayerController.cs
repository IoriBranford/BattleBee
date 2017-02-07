using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 1;
	private float _xMin = -10, _xMax = 10;

	// Use this for initialization
	void Start () {
		_xMin = Camera.main.ViewportToWorldPoint
			(new Vector3 (0, 0, 0)).x;
		_xMax = Camera.main.ViewportToWorldPoint
			(new Vector3 (1, 0, 0)).x;

		Collider2D collider = GetComponent<Collider2D> ();
		if (collider) {
			Bounds bounds = collider.bounds;
			_xMin += bounds.extents.x;
			_xMax -= bounds.extents.x;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		position.x += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
		position.x = Mathf.Clamp (position.x, _xMin, _xMax);
		transform.position = position;
	}
}
