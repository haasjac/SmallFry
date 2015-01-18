using UnityEngine;
using System.Collections;

namespace SpaceJam
{
	public class ActorWhale : Actor
	{
		public AudioClip clip;
		
		enum WhaleState {
			INTRO_1,
			INTRO_2,
			INTRO_3,
			INTRO_4,
			INTRO_5,
			INTRO_END,
			IDLE,
			RAND_1_PREP,
			RAND_1_CONT,
			RAND_1_END,
			RAND_2_PREP,
			RAND_2_END,
			CLOSE,
			FINAL_1
		}
		
		WhaleState state;
		
		// Use this for initialization
		void Start()
		{
			state = WhaleState.RAND_1_PREP;
		}
		
		// Update is called once per frame
		void Update()
		{
			
		}
		
		public override string GetName()
		{
			return "Peaceful Whale King";
		}
		
		public override Sprite GetIcon()
		{
			return Resources.Load<Sprite>("Sprites/whale");
		}
		
		public override string GetNextLine()
		{
			string line = null;
				switch (state) {
				case WhaleState.INTRO_2:
					AudioSource.PlayClipAtPoint(clip, new Vector3(0,0,0));
					
					state = WhaleState.INTRO_3;
					line = "Ah, hello my faithful little companion. Ummmm... What was your name again?";
					break;
				case WhaleState.INTRO_3:
					state = WhaleState.INTRO_4;
					line = "Right then, Small Fry. I have chosen you for a very important task! huehuehuehue";
					break;
				case WhaleState.INTRO_4:
					state = WhaleState.INTRO_5;
					line = "I need you to go up to Cheesecake Island as an emissary of our people, and make contact with the bird king!";
					break;
				case WhaleState.INTRO_5:
					state = WhaleState.CLOSE;
					line = "... well, off you go then! good luck!!! huehuehuehuehue";
					break;
				case WhaleState.CLOSE:
					GlobalState.instance.talkedToWhale = true;
					state = WhaleState.RAND_1_PREP;
					line = null;
					break;
				default:
					state = WhaleState.INTRO_2;
					line = "My oh my... Another fish, washed up on the shore.";
					break;
				}
			return line;
		}
	}
}
