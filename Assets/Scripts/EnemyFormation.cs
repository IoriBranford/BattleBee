using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float spawnDelay = 1f/64;

	private float _ampX;
	private float _freqX;
	private float _time;

	void OnDrawGizmos () {
		Gizmos.DrawWireCube(transform.position,
				new Vector3 (width, height));
	}

	void SpawnEnemiesGradually () {
		Transform position = FindFreePosition();
		if (position) {
			GameObject enemy = Instantiate (enemyPrefab,
					position.position,
					Quaternion.identity);
			enemy.transform.SetParent(position);
		}

		if (FindFreePosition()) {
			Invoke("SpawnEnemiesGradually", spawnDelay);
		}
	}

	void SpawnEnemies () {
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab,
					child.transform.position,
					Quaternion.identity);
			enemy.transform.SetParent(child);
		}
		_time = 0;
	}

	// Use this for initialization
	void Start () {
		SpawnEnemiesGradually();

		//Vector3 cameraBL = Camera.main.ViewportToWorldPoint
		//	(new Vector3 (0, 0, 0));
		//Vector3 cameraCenter = Camera.main.ViewportToWorldPoint
		//	(new Vector3 (.5f, .5f, 0));

		_ampX = width*.125f;
		_freqX = 1;
	}

	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		_time += Time.deltaTime;
		position.x = _ampX * Mathf.Sin(_time * _freqX);
		transform.position = position;

		if (EnemiesAllDead()) {
			if (!IsInvoking("SpawnEnemiesGradually")) {
				Invoke("SpawnEnemiesGradually", 2);
			}
		}
	}

	Transform FindFreePosition () {
		foreach (Transform child in transform) {
			if (child.childCount == 0) {
				return child;
			}
		}
		return null;
	}

	bool EnemiesAllDead () {
		foreach (Transform child in transform) {
			if (child.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}
