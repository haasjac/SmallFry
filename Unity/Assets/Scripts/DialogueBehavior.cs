using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace SpaceJam
{
	public class DialogueBehavior : MonoBehaviour
	{
		enum BoxState
		{
			CLOSED,		// Box is not visible i.e we are not in a dialogue
			OPENING,	// Box is in the opening animation
			OPEN,		// Box is visible i.e we are talking to someone
			CLOSING		// Box is in the closing animation
		}

		enum TextState
		{
			WRITING,	// Text is currently being written to the dialogue box
			COOLDOWN,	// Player just skipped WRITING, wait a brief moment so they dont accidentally skip the dialogue
			DONE		// Text has been written
		}

		Text textObj;		// Current dialogue text
		Text actorNameObj;	// Current actor's name
		Image imageObj;		// Current actor icon
		[SerializeField]
		Button buttonObj;	// Continue button
		RectTransform panelObj;	// Container for dialogue objects

		Actor actor;	// The current actor;
		string dialogueLine;	// The current line of dialogue that is being written to the screen
		int index;	// The character of dialogueLine to be displayed next
		BoxState boxState;
		TextState textState;
		float cooldownTimer;

		// Preserve the entire dialogue system between scenes
		void Awake()
		{
			DontDestroyOnLoad (transform.gameObject);
			cooldownTimer = 0.0f;
			dialogueLine = "";
			index = 0;
			boxState = BoxState.CLOSED;
			textState = TextState.DONE;
			actor = new DefaultActor();

			textObj = GameObject.Find("DialoguePanel/Dialogue").GetComponent<Text>();
			actorNameObj = GameObject.Find("DialoguePanel/Name").GetComponent<Text>();
			imageObj = GameObject.Find("DialoguePanel/Icon").GetComponent<Image>();
			buttonObj = GameObject.Find("DialoguePanel/ContinueButton").GetComponent<Button>();
			buttonObj.onClick.AddListener (() => { OnButtonClick(); });
			panelObj = GameObject.Find("DialoguePanel").GetComponent<RectTransform>();
		}

		// DEBUG purposes only
		void Start()
		{
			this.Talk(new DefaultActor());
		}

		// Act based on current state
		void Update()
		{
			switch(boxState)
			{
			case BoxState.CLOSED:
				break;
			case BoxState.CLOSING:
				// Make the panel invisible
				panelObj.GetComponent<CanvasGroup>().alpha = 0.0f;
				boxState = BoxState.CLOSED;
				break;
			case BoxState.OPENING:
				// Make the panel visible
				panelObj.GetComponent<CanvasGroup>().alpha = 1.0f;
				boxState = BoxState.OPEN;
				break;
			case BoxState.OPEN:
				// Do things based on textState
				switch(textState)
				{
				case TextState.DONE:
					break;
				case TextState.WRITING:
					index++;
					if (index >= dialogueLine.Length + 1) {
						index = dialogueLine.Length;
						textState = TextState.DONE;
					}
					textObj.text = dialogueLine.Substring(0, index);
					break;
				case TextState.COOLDOWN:
					cooldownTimer -= Time.deltaTime;
					if (cooldownTimer <= 0.0f) {
						textState = TextState.DONE;
						buttonObj.enabled = true;
					}
					break;
				}
				break;
			}
		}

		// Talk to an NPC based on their ID
		public void Talk(Actor _actor)
		{
			actor = _actor;

			// Get actor information
			actorNameObj.text = actor.GetName();
			if (actor.GetIcon()) {
				imageObj.sprite = actor.GetIcon();
			} else {
				// Default white icon
				imageObj.sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 64, 64), new Vector2(0f, 0f));
				Debug.Log ("Dialogue Engine failed to load a sprite from actor " + actor.GetName());
			}

			// Tell the panel to open
			OpenBox();
		}
	
		// Makes the dialogue box appear if it is not already showing
		void OpenBox()
		{
			boxState = BoxState.OPENING;
		}

		// Closes the dialogue box if it is currently showing
		void CloseBox()
		{
			if (textState == TextState.WRITING) {
				Debug.Log ("Someone tried to close the dialogue box while it was writing text!");
			} else if (boxState == BoxState.OPEN || boxState == BoxState.OPENING) {
				ForceCloseBox();
			}
		}

		// Closes the dialogue box even if it is still writing text
		void ForceCloseBox()
		{
			boxState = BoxState.CLOSING;
		}

		// What happens when the player presses the continue button
		// NOTE: This is referenced directly by name, so DON'T RENAME THIS FUNCTION
		public void OnButtonClick()
		{
			if (boxState == BoxState.OPEN) {
				switch(textState)
				{
				case TextState.COOLDOWN:
					break;
				case TextState.DONE:
					// Get the next line of dialogue
					textObj.text = "";
					index = 0;
					dialogueLine = actor.GetNextLine();
					textState = TextState.WRITING;
					break;
				case TextState.WRITING:
					// Finish writing the dialogue line to screen
					textObj.text = dialogueLine;
					// Set the cooldown timer and change state
					cooldownTimer = 0.3f;
					textState = TextState.COOLDOWN;
					buttonObj.enabled = false;
					break;
				}
			}
		}
	}
}
