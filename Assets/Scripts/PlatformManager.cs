using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {

	public int rearrangeDelay = 0;
	
	private GameManager gm;
	private MapManager mm;
	private bool seen;
	
	private float origin = 40;
	private float minOriginOffset = 20;
	private float maxOriginOffset = 40;
	
	[HideInInspector]
	public int direction; // randomized
	public float speed = 0; // randomized
	public float minSpeed;
	public float maxSpeed;
	
	void Awake() {
		gm = GameManager.instance;
		mm = gm.mapManager;

		randomizeDirection ();
	}
	
	void FixedUpdate () {
		accelerate ();
	}
	
	void OnBecameVisible ()
	{
		//Debug.Log ("seen");
		seen = true;
	}
	
	void OnBecameInvisible ()
	{
		//Debug.LogFormat ("invisible ({0}) at {1}", getId (), Time.time);
		if (seen) {
			Invoke("rearrange", rearrangeDelay);
		}
	}
	
	void rearrange ()
	{
		seen = false;
		randomizeDirection ();
		correctOrientation ();
	}
	
	public float randomizeSpeed() {
		return Random.Range (minSpeed, maxSpeed);
	}
	
	private void randomizeDirection() {
		float offset = Random.Range (minOriginOffset, maxOriginOffset);
		direction = Random.Range (0, 2);
		if (direction == 0) {
			direction = -1;
			setOrientation (45f);
			setZ (origin + offset);
		} else {
			setOrientation (-45f);
			setZ (-origin - offset);
		}
	}
	
	private void accelerate() {
			Vector3 pos = transform.position;
			pos.z += (speed * direction);
			transform.position = pos;
	}
	
	private void setZ(float z) {
		Vector3 pos = transform.position;
		pos.z = z;
		transform.position = pos;
		
		Vector3 lpos = transform.localPosition;
		lpos.y = 0f;
		lpos.x = 0f;
		transform.localPosition = lpos;
	}
	
	private void setOrientation(float value) {
		Quaternion r = transform.rotation;
		r.y = value;
		transform.rotation = r;
	}
	
	private void correctOrientation() {
		if (direction == -1)
			setOrientation (45f);
		else
			setOrientation (-45f);
	}
}
