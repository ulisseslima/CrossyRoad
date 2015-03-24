using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	int cameraVelocity = 10;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Left
		if ((Input.GetKey (KeyCode.LeftArrow))) {
			transform.Translate ((Vector3.left * cameraVelocity) * Time.deltaTime);
		}
		// Right
		if ((Input.GetKey (KeyCode.RightArrow))) {
			transform.Translate ((Vector3.right * cameraVelocity) * Time.deltaTime);
		}
		// Up
		if ((Input.GetKey (KeyCode.UpArrow))) {
			transform.Translate ((Vector3.up * cameraVelocity) * Time.deltaTime);
		}
		// Down
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate ((Vector3.down * cameraVelocity) * Time.deltaTime);
		}
	}
}
