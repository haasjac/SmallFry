using UnityEngine;
using System.Collections;
using spaceJam{
public class OstrichMG_player : MonoBehaviour {
	public float speed;
	public float jumpForce;
	private bool grounded;
	private bool jump;
	public float Accelerate;
	public static playersPOS;
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
			if (Input.GetAxis ("Horizontal") > 0)
			{
				Accelerate+= 0.01f;
				Vector3 pos = transform.position;
				pos.x += Accelerate + speed ;
				playersPOS = pos;
				transform.position = pos;
			}
			else Accelerate = 0;
			
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground") {
			grounded = true;
		}
	}
}
}
