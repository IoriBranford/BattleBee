using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[SerializeField]
	private float _damage = 1;
	public float Damage () { return _damage; }

	void OnTriggerEnter2D (Collider2D collider) {
		Destroy(gameObject);
	}
}
