using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	public float health = 1;
	private float _damage;

	// Use this for initialization
	void Start () {
		_damage = 0;
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
