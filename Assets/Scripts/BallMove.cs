using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour {
	
	Rigidbody move;
	ContactPoint hit;
	AudioSource sound;

	void Start () {
		move = GetComponent<Rigidbody> ();
		move.AddForce (Vector3.right * 1500f);
		sound = GetComponent<AudioSource> ();
	}

	void Update () {
		if (transform.position.x > 11.58f) {
			//Lives.lives -= 1;
			transform.position = new Vector3 (3.64f, 3.59f, 0.26f);
			move.velocity = Vector3.zero;
			move.AddForce (Vector3.right * 1000f);
		}
		if (move.velocity.x < .0001f) {
			Debug.Log ("Test");
			move.AddForce (Vector3.left * 10f);
		}
	}
	
	void OnCollisionEnter (Collision collisionInfo) {
		sound.Play ();
		Debug.Log ("Collision");
		Vector3 oldVelocity = move.velocity;
		ContactPoint hit = collisionInfo.contacts [0];
		Vector3 reflection = Vector3.Reflect (oldVelocity, hit.normal);
		move.velocity = Vector3.zero;
		Debug.Log (reflection);
		move.velocity = reflection;
		move.AddForce (reflection * 10f);
		Debug.Log (oldVelocity);
		Debug.Log (move.velocity);
		//Vector3 oldVelocity = move.velocity;
		//oldVelocity.x *= -1;
		//oldVelocity.z *= -1;
		//move.velocity = oldVelocity;
	
		if (collisionInfo.collider.tag == "Brick") {
			move.AddForce (Vector3.right * 100f);
			Destroy (collisionInfo.collider.gameObject);
			Debug.Log ("Brick");
			Lives.score += 100;

		}
		if (collisionInfo.collider.tag == "SpecialBrick") {
			Destroy (collisionInfo.collider.gameObject);
			Debug.Log ("SpecialBrick");
			Lives.score += 100;
		}
	}

	//void OnTriggerEnter (Collider collisionInfo) {
	//	transform.position += transform.forward * Time.deltaTime * 100f;
	//}

	//void OnTriggerExit (Collider other) {
	//	if (other.tag == "Player") {
	//		move.velocity = Vector3.Reflect (move.velocity, 
	//		move.AddForce (Vector3.left * 1000);
	//	}
	//}

}