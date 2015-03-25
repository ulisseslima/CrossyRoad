using UnityEngine;
using System.Collections;

public class ForestManager : MonoBehaviour {
	private GameManager gm;
	private MapManager mm;
	private bool seen;

	private float origin = -25;
	private int minSpacing = 0;
	private int maxSpacing = 55;

	void Awake() {
		gm = GameManager.instance;
		mm = gm.mapManager;

		randomizePosition ();
	}

	private void randomizePosition() {
		int offset = Random.Range (minSpacing, maxSpacing);
		setZ (origin + offset);
	}

	private void setZ(float z) {
		Vector3 pos = transform.position;
		pos.z = z;
		transform.position = pos;
		// Debug.Log ("Randomized tree: "+transform.position);
	}
}
