using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	private static int _Score;
	public static string ScoreString {
		get {
			return _Score.ToString();
		}
	}

	public static void Reset () {
		_Score = 0;
	}

	private Text _text;

	// Use this for initialization
	void Start () {
		_text = GetComponent<Text>();
		Reset();
		_text.text = ScoreString;
	}

	public void AddPoints (int points) {
		_Score += points;
		_text.text = ScoreString;
	}
}
