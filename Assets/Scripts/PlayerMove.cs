using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public Camera mainCamera;
	private float rotationZ = 0f;
	private float sensitivityZ = 2f;

	Vector3 temp;
	
	// Update is called once per frame
	void Update () {
		rotationZ += Input.GetAxis ("Mouse X") * sensitivityZ;
		rotationZ = Mathf.Clamp (rotationZ, -90, 90);

		temp = new Vector3 (Input.mousePosition.x, 9.5206f, 22f);
		transform.position = mainCamera.ScreenToWorldPoint (temp);
		//Debug.Log (transform.position.z);
		if (transform.position.z < -11.5f) {
			temp = new Vector3 (transform.position.x, transform.position.y, -11.5f);
			transform.position = temp;
		}
		if (transform.position.z > 11.624f) {
			temp = new Vector3 (transform.position.x, transform.position.y, 11.624f);
			transform.position = temp;
		}
		transform.Rotate (0, Input.mousePosition.y, 0);
		transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, -rotationZ, transform.localEulerAngles.z);
	}
}
