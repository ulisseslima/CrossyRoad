using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class MapManager : MonoBehaviour {

	[Serializable]
	public class Count
	{
		public int minimum;
		public int maximum;
		
		public Count (int min, int max)
		{
			minimum = min;
			maximum = max;
		}
	}

	public int rows = 20;

	public Count groundCount = new Count (2, 9);
	public Count waterCount = new Count (2, 9);
	public Count roadCount = new Count (5, 9);

	public int chanceOfGround = 20; //%
	//public int chanceOfWater = 20; //%
	public int chanceOfRoad = 80; //%

	public GameObject[] groundTypes;
	public GameObject[] roadTypes;
	public GameObject[] carTypes;
	public GameObject[] platformTypes;

	private List<GameObject> groundPool;
	private List<GameObject> waterPool;
	private List<GameObject> roadPool;

	private Transform mapHolder;
	private float xgen = 0f; // x origin for new instances of map rows

	void MapSetup ()
	{
		mapHolder = new GameObject ("Map").transform;

		for (int y = 0; y < rows; y++) {
			int diceGround = Random.Range(0, 100);
			int diceRoad = Random.Range(0, 100);
			bool isWater = false;

			Debug.Log("road dice: "+diceRoad+", ground dice: "+diceGround);
			if (diceRoad <= chanceOfRoad) {
				GameObject obj = roadTypes [Random.Range (0, roadTypes.Length)];
				GameObject instance = Instantiate (obj, new Vector3 (xgen, -.5f, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (mapHolder);
			} else if (diceGround <= chanceOfGround) {
				GameObject obj = groundTypes [Random.Range (0, groundTypes.Length)];
				GameObject instance = Instantiate (obj, new Vector3 (xgen, 0f, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (mapHolder);
			} else {
				isWater = true;
			}

			xgen+=4;
		}
	}

	public void SetupScene (int level) {
		MapSetup ();

		// TODO place cars
	}
}
