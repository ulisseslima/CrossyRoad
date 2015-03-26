using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	private GameObject[] scoreTexts;
	private int lastScore = 0;

	void Start () {
		scoreTexts = GameObject.FindGameObjectsWithTag ("Score");
	}

	void FixedUpdate () {
		foreach (GameObject go in scoreTexts) {
			go.GetComponent<Text>().text = string.Format (
				"Score: {0}\nHiscore: {1}",
				GameManager.score,
				GameManager.getHiscore());
		}

		int score = GameManager.score;
		if (lastScore != score && score % 10 == 0) {
			SoundManagerController.instance.PlayScoreMod10();
			lastScore = score;
		}
	}
}
