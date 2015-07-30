using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

	public static int lives = 3;
	public static int score = 0;
	public static int heals = 0;
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
			life3.transform.position = new Vector3 (-10, -10, -10);
			//Destroy (life3);
		}
		if (lives == 1) {
			life2.transform.position = new Vector3 (-10, -10, -10);
			//Destroy (life2);
		}
		if (heals == 1) {
			if (lives == 1) {
				life2.transform.position = new Vector3 (9.67f, 3.59f, 10.32f);
				lives += 1;
			}
			else if (lives == 2) {
				life3.transform.position = new Vector3 (9.67f, 3.59f, 10.32f);
				lives += 1;
			}
			heals -= 1;
		}
	}
//
//	public void addHeart () {
//		if (lives == 1) {
//			life2.transform.position = new Vector3 (9.67f, 3.59f, 10.32f);
//			lives += 1;
//		}
//		else if (lives == 2) {
//			life3.transform.position = new Vector3 (9.67f, 3.59f, 12.72f);
//			lives += 1;
//		}
//	}
}
