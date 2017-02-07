using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		GameObject enemy = Instantiate (enemyPrefab,
			new Vector3(0, 20, 0), Quaternion.identity);

		enemy.transform.SetParent (transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
