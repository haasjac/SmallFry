using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {
	public float speed;
	public float jumpForce;
	private bool grounded;
	private bool jump;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame 
	void Update () {

		if (Input.GetButtonDown ("Jump") && grounded) {
			jump = true;
			grounded = false;
		}


		if (Input.GetButton ("Fire2") && grounded) {
			animator.SetInteger ("Fish_anim", 2);
		} else if (Input.GetAxis ("Horizontal") != 0) {
			animator.SetInteger ("Fish_anim", 1);
			Vector3 pos = transform.position;
			pos.x += speed * Input.GetAxis ("Horizontal");
			transform.position = pos;
		} else {
			animator.SetInteger ("Fish_anim", 0);
		}
		
		if (Input.GetAxis ("Horizontal") > 0) {
			animator.SetInteger ("Direction", 1);
		} else {
			animator.SetInteger ("Direction", 0);
		}

		if(jump)
		{
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground") {
			grounded = true;
		}
	}
}
