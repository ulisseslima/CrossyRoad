using UnityEngine;
using System.Collections;

public class WaterController : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos = transform.position;
		pos.x = player.transform.position.x;
		// pos.z = player.transform.position.z;
		transform.position = pos;
	}
}
