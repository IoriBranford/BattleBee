using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer _instance;

	public AudioClip startMusic;
	public AudioClip stageMusic;

	private AudioSource _music;

	void Awake () {
		if (_instance == null) {
			GameObject.DontDestroyOnLoad(gameObject);
			_instance = this;
			SceneManager.sceneLoaded += OnLoadedScene;
			_music = GetComponent<AudioSource>();
		} else if (_instance != this) {
			Destroy(gameObject);
		}
	}

	// Between Awake and Start is when an audio source starts playing

	void OnLoadedScene (Scene scene, LoadSceneMode mode) {
		_music.Stop();
		switch (scene.name) {
		case "Start":
			_music.clip = startMusic;
			break;
		case "Stage":
			_music.clip = stageMusic;
			break;
		default:
			return;
		}
		_music.loop = true;
		_music.Play();
	}
}
