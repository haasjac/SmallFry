﻿using UnityEngine;
using System.Collections;

namespace SpaceJam
{
	public class Player_Movement : MonoBehaviour
	{
		public float speed;
		public float jumpForce;
		public float interactRange = 1.0f;

		private bool grounded;
		private bool jump;
		private bool canInteract;
		GameObject interactor;
		private Animator animator;
		DialogueBehavior dialogueEngine;
		GameObject talkIndicator;
		//private Transform groundCheck;

		// Use this for initialization
		void Start () {
			canInteract = false;
			interactor = null;
			animator = this.GetComponent<Animator>();
			dialogueEngine = GameObject.Find("DialoguePanel").GetComponent<DialogueBehavior>();
			talkIndicator = GameObject.Find("Fish/Exclamation");
			talkIndicator.renderer.enabled = false;
		}
		
		// Update is called once per frame 
		void Update ()
		{
			//grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

			// Cannot receive inputs if we are talking to someone
			if (!dialogueEngine.IsTalking())
			{
				// Jumping
				if (Input.GetButtonDown ("Jump") && grounded) {
						jump = true;
						grounded = false;
				}

				// Crouching
				if (Input.GetButton ("Hide") && grounded) {
					animator.SetInteger ("Fish_anim", 2);
				// Walking
				} else if (Input.GetAxis ("Horizontal") != 0) {
					animator.SetInteger ("Fish_anim", 1);
					Vector3 pos = transform.position;
					pos.x += speed * Input.GetAxis ("Horizontal");
					transform.position = pos;
				// Idle
				} else {
					animator.SetInteger ("Fish_anim", 0);
				}

				// Facing
				if (Input.GetAxis ("Horizontal") > 0) {
					animator.SetInteger ("Direction", 1);
				} else {
					animator.SetInteger ("Direction", 0);
				}

				// Interaction mechanics
				if (Input.GetButtonDown ("Interact") && canInteract) {
					// If the object is an Actor, talk to it
					Actor npc = interactor.GetComponent<Actor>();
					if (npc) {
						dialogueEngine.Talk(npc);
					}
				}
			} else {
				// If we are talking, progress the dialogue when the Input or Jump buttons are pressed
				if (Input.GetButtonDown("Interact") || Input.GetButtonDown("Jump")) {
					dialogueEngine.OnButtonClick();
				}
			}

			if (jump) {
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

		void OnTriggerEnter2D(Collider2D coll) {
			if (coll.gameObject.tag == "Interactable") {
				talkIndicator.renderer.enabled = true;
				canInteract = true;
				interactor = coll.gameObject;
			}
		}

		void OnTriggerExit2D(Collider2D coll) {
			if (coll.gameObject.tag == "Interactable") {
				talkIndicator.renderer.enabled = false;
				canInteract = false;
				interactor = null;
			}
		}
	}
}