using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RespawnController : MonoBehaviour
{
	private bool seen;
	private GameManager gm;
	private MapManager mm;
	public int rearrangeDelay = 0;
	public int carsPerRoad; // 3
	public int treesPerForest; // 5
	public int padsPerWater; // 10

	void Awake ()
	{
		gm = GameManager.instance;
		mm = gm.mapManager;

		if (gameObject.tag == "Road") {
			//Debug.Log ("generating traffic...");
			float speed = 0f;
			for (int i = 0; i < carsPerRoad; i++) {
				GameObject prefab = mm.carTypes [Random.Range (0, mm.carTypes.Length)];
				GameObject car = Instantiate (prefab) as GameObject;
				car.transform.SetParent (gameObject.transform);
				car.transform.localPosition = Vector3.zero;
				// Debug.Log ("new car: " + car.transform.position + ", road: " + gameObject.transform.position);

				TrafficManager tm = car.GetComponentInChildren<TrafficManager> ();
				if (speed == 0f) {
					speed = tm.randomizeSpeed ();
				}
				tm.speed = speed;
			}
		} else if (gameObject.tag == "Grass") {
			Debug.Log ("generating trees...");

			for (int i = 0; i < treesPerForest; i++) {
				GameObject prefab = mm.treeTypes [Random.Range (0, mm.treeTypes.Length)];
				GameObject tree = Instantiate (prefab) as GameObject;
				tree.transform.SetParent (gameObject.transform);
				Vector3 pos = tree.transform.localPosition;
				pos.x = 0;
				pos.y = 0;
				tree.transform.localPosition = pos;
				// Debug.Log ("new car: " + car.transform.position + ", road: " + gameObject.transform.position);
			}
		} else if (gameObject.tag == "Water") {
			Debug.Log ("generating water pads...");
			float speed = 0f;
			
			for (int i = 0; i < padsPerWater; i++) {
				GameObject prefab = mm.platformTypes [Random.Range (0, mm.platformTypes.Length)];
				GameObject pad = Instantiate (prefab) as GameObject;
				pad.transform.SetParent (gameObject.transform);
				pad.transform.localPosition = Vector3.zero;
				// Debug.Log ("new car: " + car.transform.position + ", road: " + gameObject.transform.position);
				
				PlatformManager tm = pad.GetComponentInChildren<PlatformManager> ();
				if (speed == 0f) {
					speed = tm.randomizeSpeed ();
				}
				tm.speed = speed;
			}
		}

//		scoreController = transform.parent.GetComponentInChildren<BorderController> ();
//		if (scoreController == null) {
//			Debug.LogWarning ("couldn't find score collider, points will not count");
//		}
	}

	void OnBecameVisible ()
	{
		// Debug.Log ("seen");
		seen = true;
	}

	void OnBecameInvisible ()
	{
		// Debug.Log ("invisible");
		// Debug.LogFormat ("pipe invisible ({0}) at {1}", getId (), Time.time);
		if (seen) {
			Invoke ("rearrange", rearrangeDelay);
		}
	}

	void rearrange ()
	{
		float xgen = gm.mapManager.getXgen ();
		setX (xgen);

		gm.mapManager.incXgen ();
		seen = false;
	}

	void setX (float x)
	{
		// Debug.LogFormat ("pipe new x: {0} #{1} - curr x: {2}", x, getId (), currentX);
		Transform parentTransform = gameObject.GetComponentInParent<Transform> ();
		if (parentTransform == null)
			Debug.LogError ("parent not found");

		Vector3 pos = parentTransform.position;
		pos.x = x;
		parentTransform.position = pos;
	}

	void position (GameObject go, float z)
	{
		Vector3 pos = go.transform.position;
		pos.z = z;
		go.transform.position = pos;
	}
}
