using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 1;
	public float bulletSpeed = 1;
	public float bulletInterval = 1;
	public GameObject bulletPrefab;

	private Bounds _bounds;
	private bool _fireButton;

	// Use this for initialization
	void Start () {
		Vector3 cameraBL = Camera.main.ViewportToWorldPoint
			(new Vector3 (0, 0, 0));
		Vector3 cameraTR = Camera.main.ViewportToWorldPoint
			(new Vector3 (1, 1, 0));
		Vector3 cameraCenter = Camera.main.ViewportToWorldPoint
			(new Vector3 (.5f, .5f, 0));

		_bounds = new Bounds(cameraCenter, cameraTR - cameraBL);

		Vector2 min = _bounds.min;
		Vector2 max = _bounds.max;
		foreach (var collider in GetComponents<Collider2D>()) {
			Bounds bounds = collider.bounds;
			min.x = Mathf.Max(min.x, cameraBL.x + bounds.extents.x);
			min.y = Mathf.Max(min.y, cameraBL.y + bounds.extents.y);
			max.x = Mathf.Min(max.x, cameraTR.x - bounds.extents.x);
			max.y = Mathf.Min(max.y, cameraTR.y - bounds.extents.y);
		}
		_bounds.min = min;
		_bounds.max = max;
		 _fireButton = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		float frameSpeed = speed * Time.deltaTime;
		position.x += Input.GetAxisRaw("Horizontal") * frameSpeed;
		position.y += Input.GetAxisRaw("Vertical") * frameSpeed;
		position.x = Mathf.Clamp (position.x,
				_bounds.min.x, _bounds.max.x);
		position.y = Mathf.Clamp (position.y,
				_bounds.min.y, _bounds.max.y);
		transform.position = position;

		float fireAxis = Input.GetAxis("Fire1");
		if (!_fireButton && fireAxis > 0) {
			InvokeRepeating("Fire", 1f/1024f, bulletInterval);
		} else if (_fireButton && fireAxis <= 0) {
			CancelInvoke("Fire");
		}
		_fireButton = fireAxis > 0;
	}

	void Fire () {
		Vector3 fireDirection = Vector3.up;

		GameObject bullet = Instantiate(bulletPrefab,
				transform.position + 1.5f*fireDirection,
				Quaternion.identity);

		var bulletBody = bullet.GetComponent<Rigidbody2D>();
		bulletBody.AddForce(
				fireDirection * bulletSpeed * bulletBody.mass,
				ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Bullet bullet = collider.gameObject.GetComponent<Bullet>();
		if (bullet) {
			Debug.Log("OUCH!");
			//Destroy(gameObject);
		}
	}
}
