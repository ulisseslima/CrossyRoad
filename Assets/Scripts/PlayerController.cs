using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetButton("Cancel")) {
			Restart();
			return;
		}

		int horizontal = 0;
		int vertical = 0;
		
		#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
		horizontal = (int)Input.GetAxisRaw ("Horizontal");
		vertical = (int)Input.GetAxisRaw ("Vertical");
		
		if (horizontal != 0)
			vertical = 0;
		
		#else
		if (Input.touchCount > 0) {
			Touch myTouch = Input.touches [0];
			
			if (myTouch.phase == TouchPhase.Began) {
				touchOrigin = myTouch.position;
			} else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0) {
				Vector2 touchEnd = myTouch.position;
				float x = touchEnd.x - touchOrigin.x;
				float y = touchEnd.y - touchOrigin.y;
				touchOrigin.x = -1;
				
				if (Mathf.Abs (x) > Mathf.Abs (y))
					horizontal = x > 0 ? 1 : -1;
				else
					vertical = y >= 0 ? 1 : -1;
			}
		}
		#endif

		//Debug.Log ("horizontal: "+horizontal+", vertical: "+vertical);
		if (horizontal != 0 || vertical != 0)
			jump (horizontal, vertical);
	}

	private void jump(int horizontal, int vertical) {
		if (rb.velocity.y > 0) return;

		if (horizontal < 0) {
			rb.AddForce (0f, 0f, 100f);
		} else if (horizontal > 0) {
			rb.AddForce (0f, 0f, -100f);
		} else if (vertical < 0) {
			rb.AddForce (-500f, 250, 0f);
		} else if (vertical > 0) {
			rb.AddForce(500, 250, 0f);
		}
	}

	private void Restart ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
