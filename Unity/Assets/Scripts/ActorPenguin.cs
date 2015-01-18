﻿using UnityEngine;
using System.Collections;

namespace SpaceJam
{
	public class ActorPenguin : Actor
	{

		enum PenguinState {
			INTRO_1,
			INTRO_2,
			INTRO_3,
			INTRO_4,
			INTRO_END,
			IDLE,
			RAND_1_PREP,
			RAND_1_CONT,
			RAND_1_END,
			RAND_2_PREP,
			RAND_2_END
		}

		PenguinState state;

		// Use this for initialization
		void Start()
		{
			state = PenguinState.INTRO_1;
		}
		
		// Update is called once per frame
		void Update()
		{
		
		}

		public override string GetName()
		{
			return "Wise Old Penguin";
		}
		
		public override Sprite GetIcon()
		{
			return Resources.Load<Sprite>("Sprites/penguin");
		}
		
		public override string GetNextLine()
		{
			string line = null;
			
			switch (state)
			{
			case PenguinState.INTRO_1:
				state = PenguinState.INTRO_2;
				line = "My oh my... Another fish, washed up on the shore.";
				break;
			case PenguinState.INTRO_2:
				state = PenguinState.INTRO_3;
				line = "You do know you need water to survive, don't you? You're lucky I found you here, and had a spare undiving helmet.";
				break;
			case PenguinState.INTRO_3:
				state = PenguinState.INTRO_4;
				line = "What's that? You wish to see the Bird King? Well, first you must earn the trust of the other tribes.";
				break;
			case PenguinState.INTRO_4:
				state = PenguinState.INTRO_END;
				line = "Go talk to the other birds. Once you have earned their respect, I will show you the way to our ruler.";
				break;
			case PenguinState.INTRO_END:
				state = PenguinState.RAND_1_PREP;
				line = null;
				break;
			case PenguinState.RAND_1_PREP:
				state = PenguinState.RAND_1_CONT;
				line = "Back already? I realize you're from the sea, but everyone knows you can use the left control stick to move!";
				break;
			case PenguinState.RAND_1_CONT:
				state = PenguinState.RAND_1_END;
				line = "What's a left control stick, you ask? Don't worry about it, I'm sure someone else will help you.";
				break;
			case PenguinState.RAND_1_END:
				state = PenguinState.RAND_2_PREP;
				line = null;
				break;
			case PenguinState.RAND_2_PREP:
				state = PenguinState.RAND_2_END;
				line = "Why are you still here? Don't be such a platypus - go talk to the other birds!";
				break;
			case PenguinState.RAND_2_END:
				state = PenguinState.RAND_2_PREP;
				line = null;
				break;
			}
			
			return line;
		}
	}
}