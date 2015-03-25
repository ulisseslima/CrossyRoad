using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public MapManager mapManager;

	private bool doingSetup;
	private int level = 1;

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
		mapManager = GetComponent<MapManager> ();
		InitGame ();
	}

	void InitGame ()
	{
		doingSetup = true;
		mapManager.SetupScene (level);
		doingSetup = false;
	}
}
