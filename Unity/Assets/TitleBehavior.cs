using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace SpaceJam
{
	public class TitleBehavior : MonoBehaviour
	{
		RectTransform title;
		bool done;
		DialogueBehavior dialogueEngine;

		// Use this for initialization
		void Start()
		{
			done = false;
			title = GameObject.Find ("/Canvas/TitlePanel").GetComponent<RectTransform>();
			dialogueEngine = GameObject.Find("/Canvas/DialoguePanel").GetComponent<DialogueBehavior>();
			Player_Movement.frozen = true;
		}
		
		// Update is called once per frame
		void Update()
		{
			if (Input.GetButtonDown("X_button") && !done) {
				done = true;
				Player_Movement.frozen = false;
				title.GetComponent<CanvasGroup>().alpha = 0.0f;
				Actor npc = GameObject.Find ("WhaleKing").GetComponent<Actor>();
				dialogueEngine.Talk(npc);
			}
		}
	}
}
