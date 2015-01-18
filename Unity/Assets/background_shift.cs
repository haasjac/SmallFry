using UnityEngine;

public class background_shift : MonoBehaviour {
	private Vector3 backPos;
	private float X;
	public float speed = 0.2f;
	
	void Update() {
		Vector3 pos = transform.position;
		if (Input.GetAxis ("Horizontal") > 0)
			pos.x += speed * -Input.GetAxis ("Horizontal");
		transform.position = pos;
	}

	void OnBecameInvisible()
	{

		//calculate current position
		backPos = gameObject.transform.position;
		X = backPos.x + 112;
		//calculate new position
		//Y = backPos.y + height*2;
		//move to new position when invisible
		gameObject.transform.position = new Vector3 (X, 0f, 0f);
	}
	
}