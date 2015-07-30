using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

	public static int lives = 3;
	public static int score = 0;
	public GameObject life2;
	public GameObject life3;

	// Use this for initialization
	void Start () {
		lives = 3;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (score == 4000) {
			Application.LoadLevel ("Win");
		}
		if (lives <= 0) {
			Application.LoadLevel ("Endgame");
		}
		if (lives == 2) {
			Destroy (life3);
		}
		if (lives == 1) {
			Destroy (life2);
		}
	}
}
