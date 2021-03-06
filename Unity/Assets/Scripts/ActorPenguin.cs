﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace SpaceJam
{
	public class ActorPenguin : Actor
	{
		public AudioClip clip;

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
			RAND_2_END,
			FINAL_END,
			CLOSE,
			FINAL_1
		}

		PenguinState state;

		// Use this for initialization
		void Start()
		{
			state = PenguinState.RAND_2_PREP;
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

			if (!GlobalState.instance.talkedToPenguin) {
				switch (state) {
				case PenguinState.INTRO_2:
					AudioSource.PlayClipAtPoint (clip, new Vector3 (0, 0, 0));

					state = PenguinState.INTRO_3;
					line = "You do know you need water to survive, don't you? You're lucky I found you here, and had a spare undiving helmet.";
					break;
				case PenguinState.INTRO_3:
					state = PenguinState.INTRO_4;
					line = "What's that? You wish to see the Bird King? Well, first you must earn the trust of the other tribes.";
					break;
				case PenguinState.INTRO_4:
					state = PenguinState.CLOSE;
					line = "Go talk to the other birds. Once you have earned their respect, I will show you the way to our ruler.";
					break;
				case PenguinState.CLOSE:
					GlobalState.instance.talkedToPenguin = true;
					state = PenguinState.RAND_1_PREP;
					line = null;
					break;
				default:
					state = PenguinState.INTRO_2;
					line = "My oh my... Another fish, washed up on the shore.";
					break;
				}
			} else if (GlobalState.instance.peacockGameComplete && !GlobalState.instance.pengPeacock) {
				line = "Ahh, I see you have talked to the peacocks. They sure know how to strike a pose.";
				GlobalState.instance.pengPeacock = true;
				if ((GlobalState.instance.ostrichGameComplete && !GlobalState.instance.pengOstrich) ||
				    (GlobalState.instance.seagullGameComplete && !GlobalState.instance.pengSeagull) ||
				    (GlobalState.instance.allGamesComplete))
					state = PenguinState.IDLE;
				else
					state = PenguinState.CLOSE;
			} else if (GlobalState.instance.ostrichGameComplete && !GlobalState.instance.pengOstrich) {
				line = "Looks like you learned from the ostriches and their drill sergeant. Sometimes, hiding is the smartest action.";
				GlobalState.instance.pengOstrich = true;
				if ((GlobalState.instance.seagullGameComplete && !GlobalState.instance.pengSeagull) ||
					(GlobalState.instance.allGamesComplete))
					state = PenguinState.IDLE;
				else
					state = PenguinState.CLOSE;
			} else if (GlobalState.instance.seagullGameComplete && !GlobalState.instance.pengSeagull) {
				line = "Oho, it seems you've found the seagulls. Did you know they are vegetarians?";
				GlobalState.instance.pengSeagull = true;
				if (GlobalState.instance.allGamesComplete)
					state = PenguinState.IDLE;
				else
					state = PenguinState.CLOSE;
			} else if (GlobalState.instance.allGamesComplete) {
				switch (state) {
				case PenguinState.FINAL_1:
					state = PenguinState.FINAL_END;
					line = "Go ahead and use that staircase over there to reach the Castle of the Bird King.";
					break;
				case PenguinState.FINAL_END:
					GlobalState.instance.staircaseUnlocked = true;
					state = PenguinState.RAND_1_PREP;
					SceneManager.LoadScene("Cloud_win");
					line = null;
					break;
				default:
					state = PenguinState.FINAL_1;
					line = "Well, well. Looks like you've talked to everyone. I am impressed.";
					break;
				}
			} else {
				switch(state) {
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
					state = PenguinState.CLOSE;
					line = "Why are you still here? Don't be such a platypus - go talk to the";
					if (!GlobalState.instance.pengPeacock && GlobalState.instance.pengOstrich && GlobalState.instance.pengSeagull)
						line += " peacocks!";
					else if (GlobalState.instance.pengPeacock && !GlobalState.instance.pengOstrich && GlobalState.instance.pengSeagull)
						line += " ostriches!";
					else if (GlobalState.instance.pengPeacock && GlobalState.instance.pengOstrich && !GlobalState.instance.pengSeagull)
						line += " seagulls!";
					else if (!GlobalState.instance.pengPeacock && !GlobalState.instance.pengOstrich && GlobalState.instance.pengSeagull)
						line += " peacocks and ostriches!";
					else if (GlobalState.instance.pengPeacock && !GlobalState.instance.pengOstrich && !GlobalState.instance.pengSeagull)
						line += " ostriches and seagulls!";
					else if (!GlobalState.instance.pengPeacock && GlobalState.instance.pengOstrich && !GlobalState.instance.pengSeagull)
						line += " peacocks and seagulls!";
					else if (!GlobalState.instance.pengPeacock && !GlobalState.instance.pengOstrich && !GlobalState.instance.pengSeagull)
						line += " peacocks, ostriches and seagulls!";
					break;
				case PenguinState.CLOSE:
					state = PenguinState.RAND_2_PREP;
					line = null;
					break;
				}
			}
			
			return line;
		}
	}
}
