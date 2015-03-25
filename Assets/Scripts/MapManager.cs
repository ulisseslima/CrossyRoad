using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class MapManager : MonoBehaviour
{
	public int poolSize; // 10
	private int smallestCache = 0; // smallest cache size

	public int chanceOfGround; // 20%
	public int chanceOfWater; // 30%
	public int chanceOfRoad; // 80%

	public GameObject[] groundTypes;
	public GameObject[] roadTypes;
	public GameObject[] platformTypes;
	public GameObject[] treeTypes;
	public GameObject[] carTypes;

	private List<GameObject> groundPool = new List<GameObject> ();
	private List<GameObject> waterPool = new List<GameObject> ();
	private List<GameObject> roadPool = new List<GameObject> ();
	private Transform mapHolder;
	private float xgen = 0f; // x origin for new instances of map rows

	public float getXgen() {
		return xgen;
	}

	public void incXgen() {
		xgen+=4;
	}

	void MapSetup ()
	{
		mapHolder = new GameObject ("Map").transform;

		while (smallestCache < poolSize) {
			int diceGround = dice();
			int diceRoad = dice();
			bool isWater = false;

			//Debug.Log ("road dice: " + diceRoad + ", ground dice: " + diceGround);
			if (diceRoad <= chanceOfRoad && roadPool.Count < poolSize) {
				GameObject road = roadTypes [Random.Range (0, roadTypes.Length)];
				GameObject instance = Instantiate (road, new Vector3 (xgen, -.5f, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (mapHolder);
				roadPool.Add (instance);
			} else if (diceGround <= chanceOfGround && groundPool.Count < poolSize) {
				GameObject ground = groundTypes [Random.Range (0, groundTypes.Length)];
				GameObject instance = Instantiate (ground, new Vector3 (xgen, 0f, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (mapHolder);
				groundPool.Add (instance);
			} else {
				isWater = true;
			}

			cacheControl ();
			xgen += 4;
		}

		Debug.Log ("done: " + smallestCache + ", roadPool: " + roadPool.Count + ", groundPool: " + groundPool.Count);
	}

	/**
	 * Dice roll 
	 */
	public int dice() {
		return Random.Range (0, 100);
	}

	private void cacheControl ()
	{
		smallestCache = groundPool.Count < roadPool.Count ? 
			groundPool.Count : roadPool.Count;
	}

	public void SetupScene (int level)
	{
		MapSetup ();

		// TODO place cars
	}
}
