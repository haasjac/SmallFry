using UnityEngine;
using System.Collections;

namespace SpaceJam
{
	public class Player_Movement : MonoBehaviour
	{
		public float speed;
		public float jumpForce;
		public float interactRange = 1.0f;
		public static bool frozen = false;

		private float horiz = 0;
		private bool grounded;
		private bool jump;
		private bool canInteract;
		GameObject interactor;
		private Animator animator;
		DialogueBehavior dialogueEngine = null;
		GameObject talkIndicator;
		//private Transform groundCheck;

		// Use this for initialization
		void Start () {
			canInteract = false;
			interactor = null;
			animator = this.GetComponent<Animator>();
			if (GameObject.Find("/Canvas/DialoguePanel"))
				dialogueEngine = GameObject.Find("/Canvas/DialoguePanel").GetComponent<DialogueBehavior>();
			talkIndicator = GameObject.Find("Fish/Exclamation");
			talkIndicator.renderer.enabled = false;

			if (Application.loadedLevelName.Equals ("Beach_Penguin") && !GlobalState.instance.talkedToPenguin) {
				interactor = GameObject.Find("Penguin");
				dialogueEngine.Talk(interactor.GetComponent<Actor>());
			}

			// TODO: Spawn on the correct side based on GlobalState.instance.enterSide
		}
		
		// Update is called once per frame 
		void Update ()
		{
			//grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

			// Cannot receive inputs if we are talking to someone
			if (!frozen && (!dialogueEngine || !dialogueEngine.IsTalking()))
			{
				horiz = Input.GetAxis ("Horizontal");
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
					pos.x += speed * horiz;
					transform.position = pos;
				// Idle
				}else {
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
						// Turn on the idle animation
						animator.SetInteger ("Fish_anim", 0);

						// Special case for the seagull game
						if (Application.loadedLevelName.Equals("Seagull_Game")) {
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
