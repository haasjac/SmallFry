using UnityEngine;
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

		GUIText textObj;	// Current dialogue text
		GUIText actorNameObj;	// Current actor's name
		GameObject imageObj;	// Current actor icon
		GameObject panelObj;	// GUIPanel object: container for information objects

		string actor;	// TODO: Change to an Actor object
		BoxState boxState;
		TextState textState;
		float cooldownTimer;

		// Preserve the entire dialogue system between scenes
		void Awake()
		{
			DontDestroyOnLoad (transform.gameObject);
			cooldownTimer = 0.0f;
			boxState = BoxState.CLOSED;
			textState = TextState.DONE;

			textObj = GameObject.Find("DialoguePanel/Icon/Dialogue").guiText;
			actorNameObj = GameObject.Find("DialoguePanel/Icon/Name").guiText;
			imageObj = GameObject.Find("DialoguePanel/Icon");

		}

		// Act based on current state
		void Update()
		{
			switch(boxState)
			{
			case BoxState.CLOSED:
				break;
			case BoxState.CLOSING:
				// TODO: Continue closing animation or change state to CLOSED

				break;
			case BoxState.OPENING:
				// TODO: Continue opening animation or change state to OPEN
				break;
			case BoxState.OPEN:
				// Do things based on textState
				switch(textState)
				{
				case TextState.DONE:
					break;
				case TextState.WRITING:
					// TODO: Continue writing text
					break;
				case TextState.COOLDOWN:
					// TODO: Decrement cooldown counter
					break;
				}
				break;
			}
		}

		// Talk to an NPC based on their ID
		public void Talk(int actor_id)
		{
			// TODO: Look up the actor by ID using our actor database
			// TODO: Determine which line of dialogue to display
		}
	
		// Makes the dialogue box appear if it is not already showing
		void OpenBox()
		{
			// TODO: Make the dialog box appear
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
			// TODO: Initiate box closing animation
		}

		// TODO: Verify this is the proper function name
		// What happens when the player presses the "next" button
		void OnButtonClick()
		{
			if (boxState == BoxState.OPEN) {
				switch(textState)
				{
				case TextState.COOLDOWN:
					break;
				case TextState.DONE:
					// TODO: Go to next line of dialogue or close the dialogue box
					break;
				case TextState.WRITING:
					// TODO: Finish writing the text

					// Set the cooldown timer and change state
					cooldownTimer = 0.3f;
					textState = TextState.COOLDOWN;
					break;
				}
			}
		}
	}
}
