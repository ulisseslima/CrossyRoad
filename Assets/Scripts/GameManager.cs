using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;
	public static int score = 0;
	public static int hiscore;
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

		hiscore = PlayerPrefs.GetInt ("hiscore", 0);

		mapManager = GetComponent<MapManager> ();
		InitGame ();
	}

	void InitGame ()
	{
		doingSetup = true;
		mapManager.SetupScene (level);
		doingSetup = false;
	}

	public static void addScore ()
	{
		score++;
		if (score > hiscore) {
			hiscore = score;
		}
	}

	public static int getHiscore ()
	{
		return hiscore;
	}

	void OnDestroy ()
	{
		PlayerPrefs.SetInt ("hiscore", hiscore);
	}
}
