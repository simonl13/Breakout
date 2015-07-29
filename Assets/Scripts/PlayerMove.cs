using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	Rigidbody move;
	float y;
	public Camera mainCamera;
	Vector3 temp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		temp = Input.mousePosition;
		temp.z = transform.position.z - mainCamera.transform.position.z;
		transform.position = mainCamera.ScreenToWorldPoint (temp);

		//y = Input.GetAxis ("Mouse X");
		//Vector3 localForce = TransformD(new Vector3(9, 3, y);
		//localForce.y = 0;
		//move.AddForce(localForce);
	}
}
