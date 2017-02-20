using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;

	private float _ampX;
	private float _freqX;
	private float _time;

	void OnDrawGizmos () {
		Gizmos.DrawWireCube(transform.position,
				new Vector3 (width, height));
	}

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab,
					child.transform.position,
					Quaternion.identity);
			enemy.transform.SetParent(child);
		}
		_time = 0;

		Vector3 cameraBL = Camera.main.ViewportToWorldPoint
			(new Vector3 (0, 0, 0));
		Vector3 cameraCenter = Camera.main.ViewportToWorldPoint
			(new Vector3 (.5f, .5f, 0));

		_ampX = (cameraCenter - cameraBL).x - width*.5f;
		_freqX = 2;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		_time += Time.deltaTime;
		position.x = _ampX * Mathf.Sin(_time * _freqX);
		transform.position = position;
	}
}
