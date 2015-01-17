using UnityEngine;
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
		DialogueBehavior dialogueEngine;
		//private Transform groundCheck;

		// Use this for initialization
		void Start () {
			//groundCheck = transform.Find ("groundCheck");

			dialogueEngine = GameObject.Find ("DialoguePanel").GetComponent<DialogueBehavior> ();
		}
		
		// Update is called once per frame 
		void Update ()
		{
			//grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

			// Cannot receive inputs if we are talking to someone
			if (!dialogueEngine.IsTalking ())
			{
				// Jumping
				if (Input.GetButtonDown ("Jump") && grounded) {
						jump = true;
						grounded = false;
				}

				// Movement
				if (Input.GetAxis ("Horizontal") != 0) {
					Vector3 pos = transform.position;
					pos.x += speed * Input.GetAxis ("Horizontal");
					transform.position = pos;
				}

				// Interaction mechanics
				if (Input.GetButtonDown ("Interact")) {
					GameObject[] interactions = GameObject.FindGameObjectsWithTag("Interactable");
					if (interactions.Length > 0) {
						// Find the closest interactable object
						GameObject closest = null;
						float closestDist = float.MaxValue;
						foreach (GameObject x in interactions) {
							float distance = (x.transform.position - transform.position).sqrMagnitude;
							if (distance < closestDist) {
								closest = x;
								closestDist = distance;
							}
						}
						
						// If it is within range, Interact with it
						if ((closest.transform.position - transform.position).sqrMagnitude < interactRange) {
							// If the object is an Actor, talk to it
							Actor npc = closest.GetComponent<Actor>();
							if (npc) {
								dialogueEngine.Talk(npc);
							}
						}
					}
				}
			} else {
				// If we are talking, progress the dialogue when the Input or Jump buttons are pressed
				if (Input.GetButtonDown("Interact") || Input.GetButtonDown("Jump")) {
					dialogueEngine.OnButtonClick();
				}
			}

			if(jump) {
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
}
