using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	private int _score;
	private Text _text;

	// Use this for initialization
	void Start () {
		_text = GetComponent<Text>();
		Reset();
	}

	void Reset () {
		_score = 0;
		_text.text = "0";
	}

	public void AddPoints (int points) {
		_score += points;
		_text.text = _score.ToString();
	}
}
