using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	public float health = 1;
	public float bulletSpeed = 1;
	public float bulletInterval = 1;
	public GameObject bulletPrefab;

	private float _damage;

	void Start () {
		_damage = 0;
	}

	void Update () {
		if (!IsInvoking("Fire")) {
			float interval = Random.Range(
					bulletInterval * .5f,
					bulletInterval);
			Invoke("Fire", interval);
		}
	}

	void Fire () {
		Vector3 fireDirection = Vector3.down;

		var player = GameObject.FindObjectOfType<PlayerController> ();
		if (player) {
			fireDirection = player.transform.position
				- transform.position;
			fireDirection.Normalize();
		}

		GameObject bullet = Instantiate(bulletPrefab,
				transform.position + 1.5f*fireDirection,
				Quaternion.LookRotation(Vector3.forward,
					fireDirection));

		var bulletBody = bullet.GetComponent<Rigidbody2D>();
		bulletBody.AddForce(
				fireDirection * bulletSpeed * bulletBody.mass,
				ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Bullet bullet = collider.gameObject.GetComponent<Bullet>();
		if (bullet) {
			_damage += bullet.Damage();
			if (_damage >= health) {
				Destroy(gameObject);
			}
		}
	}
}
