using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
	public float speedY = 1f;

	private float _maxOffsetX;

	// Use this for initialization
	void Start () {
		var camera = Camera.main;
		Vector3 cameraBL = Camera.main.ViewportToWorldPoint
			(new Vector3 (0, 0, 0));
		Vector3 cameraTR = Camera.main.ViewportToWorldPoint
			(new Vector3 (1, 1, 0));

		float cameraW = cameraTR.x - cameraBL.x;
		float width = transform.localScale.x;
		_maxOffsetX = 1f - (cameraW / width);
	}

	// Update is called once per frame
	void Update () {
		var renderer = GetComponent<MeshRenderer>();
		Material material = renderer.material;
		Vector2 offset = material.mainTextureOffset;

		var player = GameObject.FindObjectOfType<PlayerController>();
		var camera = Camera.main;
		if (player && camera) {
			Vector3 playerVPPos = camera.WorldToViewportPoint(
					player.transform.position);

			offset.x = playerVPPos.x * _maxOffsetX;
		}

		offset.y += Time.deltaTime * speedY;

		material.mainTextureOffset = offset;
	}
}
