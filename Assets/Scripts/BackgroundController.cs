using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		var renderer = GetComponent<MeshRenderer>();
		Material material = renderer.material;
		Vector2 offset = material.mainTextureOffset;

		offset.y += Time.deltaTime;

		material.mainTextureOffset = offset;
	}
}
