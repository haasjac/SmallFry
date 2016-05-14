using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

namespace SpaceJam
{
	public class Player_Movement : MonoBehaviour
	{
		public float speed;
		public float jumpForce;
		public float interactRange = 1.0f;
		public static bool frozen = false;

		private float horiz;
		private bool grounded;
		private bool jump;
		private bool canInteract;
		GameObject interactor;
		private Animator animator;
		DialogueBehavior dialogueEngine;
		GameObject talkIndicator;
		//private Transform groundCheck;

		// Use this for initialization
		void Start()
		{
			jump = false;
			horiz = 0;
			canInteract = false;
			interactor = null;
			animator = this.GetComponent<Animator>();
			if (GameObject.Find("/Canvas/DialoguePanel"))
				dialogueEngine = GameObject.Find("/Canvas/DialoguePanel").GetComponent<DialogueBehavior>();
			talkIndicator = GameObject.Find("Fish/Exclamation");
			talkIndicator.GetComponent<Renderer>().enabled = false;

			if (SceneManager.GetActiveScene().name == "Beach_Penguin" && !GlobalState.instance.talkedToPenguin) {
				interactor = GameObject.Find("Penguin");
				dialogueEngine.Talk(interactor.GetComponent<Actor>());
			}

			List<string> levels = new List<string>() {"Beach_Penguin", "Beach_Seagull", "Garden", "Desert"};

			if (levels.Exists(x => x == SceneManager.GetActiveScene().name)) {
				if (GlobalState.instance.enterSide == GlobalState.ScreenSide.LEFT) {
					Vector3 pos = transform.position;
					pos.x  = -20;
					transform.position = pos;
				} else if (GlobalState.instance.enterSide == GlobalState.ScreenSide.RIGHT) {
					Vector3 pos = transform.position;
					pos.x  = 20;
					transform.position = pos;
				}
			}

			// TODO: Spawn on the correct side based on GlobalState.instance.enterSide
		}
		
		// Update is called once per frame 
		void Update ()
		{
			//grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
			if (canInteract && !dialogueEngine.IsTalking ()) {
				talkIndicator.GetComponent<Renderer>().enabled = true;
			} else {
				talkIndicator.GetComponent<Renderer>().enabled = false;
			}

			// Cannot receive inputs if we are talking to someone
			if (!frozen && (!dialogueEngine || !dialogueEngine.IsTalking()))
			{
				horiz = Input.GetAxis ("Horizontal");
				// Jumping
				if (Input.GetButtonDown ("Jump") && grounded) {
						jump = true;
						grounded = false;
				}

				// Crouching - Can only crouch if we have beaten or are currently playing the ostrich game
				if (Input.GetButton ("Hide") && grounded && (GlobalState.instance.ostrichGameComplete || SceneManager.GetActiveScene().name == "Ostrich_Game")) {
					animator.SetInteger ("Fish_anim", 2);
				// Walking
				} else if (!grounded) {
					animator.SetInteger ("Fish_anim", 3);
					Vector3 pos = transform.position;
					pos.x += speed * horiz;
					transform.position = pos;
				} else if (Input.GetAxis ("Horizontal") != 0) {
					animator.SetInteger ("Fish_anim", 1);
					Vector3 pos = transform.position;
					pos.x += speed * horiz;
					transform.position = pos;
				// Posing
				} else if (Input.GetAxis("Pose_vert") > 0 && GlobalState.instance.peacockGameComplete) {
					animator.SetInteger("Fish_anim", 5);
					print ("pose");
				} else if (Input.GetAxis("Pose_vert") < 0 && GlobalState.instance.peacockGameComplete) {
					animator.SetInteger("Fish_anim", 6);
					print ("pose");
				} else if (Input.GetAxis("Pose_horiz") > 0 && GlobalState.instance.peacockGameComplete) {
					animator.SetInteger("Fish_anim", 7);
					print ("pose");
				} else if (Input.GetAxis("Pose_horiz") < 0 && GlobalState.instance.peacockGameComplete) {
					animator.SetInteger("Fish_anim", 8);
					print ("pose");
					// Idle
				} else {
					animator.SetInteger ("Fish_anim", 0);
				}

				// Facing
				if (Input.GetAxis ("Horizontal") >= 0) {
					animator.SetInteger ("Direction", 1);
				} else {
					animator.SetInteger ("Direction", 0);
				}

				// Interaction mechanics
				if (Input.GetButtonDown ("Interact") && canInteract) {

					// If the object is an Actor, talk to it
					Actor npc = interactor.GetComponent<Actor>();
					if (npc) {
						// Turn on the idle animation
						animator.SetInteger ("Fish_anim", 0);

						// Special case for the seagull game
						if (SceneManager.GetActiveScene().name == "Seagull_Game") {
							GlobalState.instance.seagullGameComplete = true;
						}

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
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
				
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
				canInteract = true;
				interactor = coll.gameObject;
			}
		}

		void OnTriggerExit2D(Collider2D coll) {
			if (coll.gameObject.tag == "Interactable") {
				canInteract = false;
				interactor = null;
			}
		}
	}
}
