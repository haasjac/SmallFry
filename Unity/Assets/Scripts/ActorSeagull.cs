using UnityEngine;
using System.Collections;

namespace SpaceJam
{
	public class ActorSeagull : Actor
	{
		enum SeagullState {
			IDLE,
			DIALOG_1,
			DIALOG_2,
			DIALOG_3,
			DIALOG_4,
			DIALOG_END,
			DIALOG_DONE,
			AFTER_MG_IDLE
		}

		SeagullState state;

		// Use this for initialization
		void Start()
		{
			state = SeagullState.IDLE;
		}
		
		// Update is called once per frame
		void Update()
		{
		
		}

		public override string GetName()
		{
			return "Sir Sterling Seagull, Esq. IV";
		}
		
		public override Sprite GetIcon()
		{
			return Resources.Load<Sprite>("Sprites/cumberbatch");
		}
		
		public override string GetNextLine()
		{
			string line = null;
			
			switch (state)
			{
			case SeagullState.IDLE:
				state = SeagullState.DIALOG_1;
				line = "Fufufufu... What have we here?";
				break;
			case SeagullState.DIALOG_1:
				state = SeagullState.DIALOG_2;
				line = "Good sir, you look positively... delicious.";
				break;
			case SeagullState.DIALOG_2:
				state = SeagullState.DIALOG_3;
				line = "I'm sure a strong, handsome fellow such as yourself could give me a helping... ah... fin!";
				break;
			case SeagullState.DIALOG_3:
				state = SeagullState.DIALOG_4;
				line = "I seem to have misplaced my fishi - errr, Nourishment Acquiring Apparatus.";
				break;
			case SeagullState.DIALOG_4:
				state = SeagullState.DIALOG_END;
				line = "Be a dear and go fetch it for me, won't you? Fufufufu...";
				break;
			case SeagullState.DIALOG_END:
				state = SeagullState.DIALOG_DONE;
				line = null;
				Application.LoadLevel("Seagull_Game");
				break;
			}
			
			return line;
		}
	}
}
