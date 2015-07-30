using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {
	AudioSource sound;

	void Start() {
		sound = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			Application.LoadLevel ("GameScene");
			sound.Play ();
		}
	}
}
