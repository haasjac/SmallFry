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
			AFTER_MG_IDLE,
			AFTER_MG_1,
			AFTER_MG_2,
			AFTER_MG_3,
			CLOSE
		}

		SeagullState state;

		// Use this for initialization
		void Start()
		{
			state = SeagullState.IDLE;
			if (Application.loadedLevelName.Equals("Seagull_Game")) {
				gameObject.tag = "Untagged";
			}
		}
		
		// Update is called once per frame
		void Update()
		{
			if (Application.loadedLevelName.Equals("Seagull_Game")) {
				if (GlobalState.instance.fishingRodGet) {
					gameObject.tag = "Interactable";
				} else {
					gameObject.tag = "Untagged";
				}
			}
		}

		public override string GetName()
		{
			return "Sir Sterling Seagull, Esq. IV";
		}
		
		public override Sprite GetIcon()
		{
			return Resources.Load<Sprite>("Sprites/seagull");
		}
		
		public override string GetNextLine()
		{
			string line = null;

			if (!GlobalState.instance.seagullGameComplete) {
				switch (state) {
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
					Application.LoadLevel ("Seagull_Game");
					break;
				}
			} else {
				if (GlobalState.instance.talkedToSeagull) {
					switch(state) {
					case SeagullState.CLOSE:
						state = SeagullState.AFTER_MG_IDLE;
						line = null;
						break;
					default:
						state = SeagullState.CLOSE;
						line = "Thank you again for your assistance!";
						break;
					}
				} else {
					switch(state) {
					case SeagullState.AFTER_MG_1:
						state = SeagullState.AFTER_MG_2;
						line = "And now, I think it's time to catch ourselves some delicious, nutritious...";
						break;
					case SeagullState.AFTER_MG_2:
						state = SeagullState.CLOSE;
						line = "Sea cucumbers! Oh, how I do love sea cucumbers!";
						break;
					case SeagullState.CLOSE:
						state = SeagullState.AFTER_MG_IDLE;
						line = null;
						GlobalState.instance.talkedToSeagull = true;
						Application.LoadLevel("Beach_Seagull");
						break;
					default:
						state = SeagullState.AFTER_MG_1;
						line = "Fufufufu! Thank you kindly, master fish.";
						break;
					}
				}
			}
			
			return line;
		}
	}
}
