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
			Lives.lives -= 1;
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
		Vector3 oldVelocity = move.velocity;
		ContactPoint hit = collisionInfo.contacts [0];
		Vector3 reflection = Vector3.Reflect (oldVelocity, hit.normal);
		move.velocity = reflection;
		//move.AddForce (reflection * 100f);
		//Vector3 oldVelocity = move.velocity;
		//oldVelocity.x *= -1;
		//oldVelocity.z *= -1;
		//move.velocity = oldVelocity;
	
		if (collisionInfo.collider.tag == "Brick") {
			move.AddForce (Vector3.right);
			Destroy (collisionInfo.collider.gameObject);

			Debug.Log ("Brick Collision");

			Lives.score += 100;

		}
		if (collisionInfo.collider.tag == "SpecialBrick") {
			Destroy (collisionInfo.collider.gameObject);
			Debug.Log ("Special Brick Collision");
			Lives.score += 100;
			if (Lives.lives < 3) {
				Lives.heals += 1;
			}
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