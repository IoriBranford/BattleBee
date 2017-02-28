using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
	void Start () {
		Text text = GetComponent<Text> ();
		text.text = ScoreKeeper.ScoreString;
		ScoreKeeper.Reset();
	}
}
