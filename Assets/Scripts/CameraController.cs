using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	GameObject player;
	int cameraVelocity = 40;
	int xoffset = -10;
	int zoffset = -10;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 pos = transform.position;
		pos.x = player.transform.position.x + xoffset;
		// pos.z = player.transform.position.z + zoffset;
		transform.position = pos;

		// Left
		if ((Input.GetKey (KeyCode.J))) {
			transform.Translate ((Vector3.left * cameraVelocity) * Time.deltaTime);
		}
		// Right
		if ((Input.GetKey (KeyCode.L))) {
			transform.Translate ((Vector3.right * cameraVelocity) * Time.deltaTime);
		}
		// Up
		if ((Input.GetKey (KeyCode.I))) {
			transform.Translate ((Vector3.up * cameraVelocity) * Time.deltaTime);
		}
		// Down
		if (Input.GetKey (KeyCode.K)) {
			transform.Translate ((Vector3.down * cameraVelocity) * Time.deltaTime);
		}
	}
}
