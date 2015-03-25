using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	public GameObject gameManager;

	void Awake () {
		Debug.Log ("loading...");
		if (GameManager.instance == null)
			Instantiate (gameManager);
	}
}
