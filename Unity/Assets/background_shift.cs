using UnityEngine;

public class background_shift : MonoBehaviour {
	private Vector3 backPos;
	public float width = 14.22f;
	public float height = 0f;
	private float X;
	private float Y;
	private float sign = 1;
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
		gameObject.transform.position = new Vector3 (X, Y, 0f);
	}
	
}