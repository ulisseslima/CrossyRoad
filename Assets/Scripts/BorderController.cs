using UnityEngine;
using System.Collections;

public class BorderController : MonoBehaviour
{
	void OnTriggerEnter (Collider collider)
	{
		if (!enabled) {
			return;
		}

		if (collider.tag == "PlayerBody") {
			GameManager.addScore();
		}
	}
}
