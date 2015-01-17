using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {
	public float speed;
	public float jumpForce;
	private bool grounded;
	private bool jump;
	//private Transform groundCheck;

	// Use this for initialization
	void Start () {
		//groundCheck = transform.Find ("groundCheck");
	}
	
	// Update is called once per frame 
	void Update () {

		//grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetButtonDown ("Jump") && grounded) {
			jump = true;
			grounded = false;
		}

		if(jump)
		{
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}


		if (Input.GetAxis ("Horizontal") != 0) {
			Vector3 pos = transform.position;
			pos.x += speed * Input.GetAxis ("Horizontal");
			transform.position = pos;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground") {
			grounded = true;
		}
	}
}
