using UnityEngine;
using System.Collections;

namespace SpaceJam
{
	public class PlatypusActor : Actor
	{
		enum PlatypusState {
			IDLE,
			DIALOG_1,
			DIALOG_2,
			DIALOG_3,
			CLOSE,
			DONE
		}

		PlatypusState state;

		// Use this for initialization
		void Start()
		{
			state = PlatypusState.IDLE;
		}
		
		// Update is called once per frame
		void Update()
		{
		
		}

		public override string GetName()
		{
			switch (state) {
			case PlatypusState.IDLE:
				return "Platypus King";
			default:
				return "\"Eagle\" King";
			}
		}
		
		public override Sprite GetIcon()
		{
			return Resources.Load<Sprite>("Sprites/platypus");
		}
		
		public override string GetNextLine()
		{
			string line = null;
			
			switch (state) {
			case PlatypusState.IDLE:
				state = PlatypusState.DIALOG_1;
				line = "Who dares enter the domain of the great EAGLE KING???";
				break;
			case PlatypusState.DIALOG_1:
				state = PlatypusState.DIALOG_2;
				line = "...What's that, Small Fry? The Peaceful Whale King has sent you to form relations between our species?";
				break;
			case PlatypusState.DIALOG_2:
				state = PlatypusState.DIALOG_3;
				line = "Wonderful! The Eagle King gladly accepts! And to celebrate this happy union, we shall have...";
				break;
			case PlatypusState.DIALOG_3:
				state = PlatypusState.CLOSE;
				line = "A DANCE PARTY!";
				break;
			case PlatypusState.CLOSE:
				state = PlatypusState.DONE;
				line = null;
				Application.LoadLevel("you_win");
				break;
			}
			
			return line;
		}
	}
}
