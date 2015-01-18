using UnityEngine;
using System.Collections;

namespace SpaceJam
{
	public class ActorOstrich : Actor
	{
		enum OstrichState {
			IDLE,
			DIALOG_1,
			DIALOG_2,
			DIALOG_3,
			DIALOG_END,
			DIALOG_DONE,
			AFTER_MG_IDLE
		}

		OstrichState state;

		// Use this for initialization
		void Start()
		{
			state = OstrichState.IDLE;
		}
		
		// Update is called once per frame
		void Update()
		{
		
		}

		public override string GetName()
		{
			string name = "";

			switch(state)
			{
			case OstrichState.IDLE:
			case OstrichState.DIALOG_2:
				name = "Olly Ostrich";
				break;
			case OstrichState.DIALOG_1:
				name = "???";
				break;
			case OstrichState.DIALOG_3:
				name = "Sergeant Hummingbird";
				break;
			}

			return name;
		}
		
		public override Sprite GetIcon()
		{
			Sprite icon = Resources.Load<Sprite>("Sprites/ostrich");

			switch(state)
			{
			case OstrichState.IDLE:
			case OstrichState.DIALOG_2:
				icon = Resources.Load<Sprite>("Sprites/ostrich");
				break;
			case OstrichState.DIALOG_1:
				icon = Resources.Load<Sprite>("Sprites/question");
				break;
			case OstrichState.DIALOG_3:
				icon = Resources.Load<Sprite>("Sprites/hummingbird");
				break;
			}

			return icon;
		}
		
		public override string GetNextLine()
		{
			string line = null;
			
			switch (state)
			{
			case OstrichState.IDLE:
				state = OstrichState.DIALOG_1;
				line = "Shh! Get down and hide, or the sergeant will find us!";
				break;
			case OstrichState.DIALOG_1:
				state = OstrichState.DIALOG_2;
				line = "What are you doing slacking off, soldiers? GET BACK TO TRAINING!";
				break;
			case OstrichState.DIALOG_2:
				state = OstrichState.DIALOG_3;
				line = "Ahh! He found us!";
				break;
			case OstrichState.DIALOG_3:
				state = OstrichState.DIALOG_END;
				line = "Everyone, get on the track and RUN! That means you, blubberbrains!";
				break;
			case OstrichState.DIALOG_END:
				state = OstrichState.DIALOG_DONE;
				line = null;
				Application.LoadLevel("Ostrich_Game");
				break;
			}
			
			return line;
		}
	}
}