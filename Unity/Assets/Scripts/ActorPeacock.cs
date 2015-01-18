using UnityEngine;
using System.Collections;

namespace SpaceJam
{
	public class ActorPeacock : Actor
	{
		public AudioClip clip;
		enum PeacockState {
			IDLE,
			INTRO_DIALOG_1,
			INTRO_DIALOG_2,
			INTRO_DIALOG_END,
			INTRO_DIALOG_DONE,
			AFTER_MG_IDLE,
            CLOSE
		}

		PeacockState state;

		// Use this for initialization
		void Start()
		{
			state = PeacockState.IDLE;
		}
		
		// Update is called once per frame
		void Update()
		{
		
		}

		public override string GetName()
		{
			return "Penelope Peacock";
		}
		
		public override Sprite GetIcon()
		{
			return Resources.Load<Sprite>("Sprites/peacock");
		}
		
		public override string GetNextLine()
		{
			string line = null;

			if (GlobalState.instance.peacockGameComplete) {
                switch(state) {
                case PeacockState.CLOSE:
                    state = PeacockState.AFTER_MG_IDLE;
                    line = null;
                    break;
                default:
                    state = PeacockState.CLOSE;
                    line = "Now you can be FABULOUS using the D-Pad!";
                    break;
                }
			} else {
				switch (state)
				{
				case PeacockState.IDLE:
					state = PeacockState.INTRO_DIALOG_1;
					AudioSource.PlayClipAtPoint(clip, new Vector3(0,0,0));

					line = "Oh em GEEE, I thought you were one of those hideous platypuseses!";
					break;
				case PeacockState.INTRO_DIALOG_1:
					state = PeacockState.INTRO_DIALOG_2;
					line = "You know what would make you more beautiful? Do runway poses with me!";
					break;
				case PeacockState.INTRO_DIALOG_2:
					state = PeacockState.INTRO_DIALOG_END;
					line = "If you do enough, I'll show you how to do them anytime you want! Come on!";
					break;
				case PeacockState.INTRO_DIALOG_END:
					state = PeacockState.INTRO_DIALOG_DONE;
					line = null;
					Application.LoadLevel("Peacock_Game");
					break;
				}
			}
			
			return line;
		}
	}
}
