using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public MapManager mapManager;

	private List<GameObject> cars;
	private bool doingSetup;
	private int level = 1;

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
		cars = new List<GameObject> ();
		mapManager = GetComponent<MapManager> ();
		InitGame ();
	}

	void InitGame ()
	{
		doingSetup = true;
		cars.Clear ();
		mapManager.SetupScene (level);
		doingSetup = false;
	}
}
