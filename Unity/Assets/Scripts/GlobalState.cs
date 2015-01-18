using UnityEngine;
using System.Collections;

namespace SpaceJam
{
	// Singleton class to hold global states such as dialogue state, etc.
	public class GlobalState
	{
		public enum ScreenSide {
			LEFT,
			RIGHT
		}

		private static GlobalState _instance;

		public static GlobalState instance
		{
			get
			{
				if (_instance == null) {
					_instance = new GlobalState();
				}
				return _instance;
			}
		}

		// Global states
		public bool ostrichGameComplete;	// Have we completed the Ostrich minigame?
		public bool peacockGameComplete;	// Have we completed the Peacock minigame?
		public bool seagullGameComplete;	// Have we completed the Seagull minigame?
		public bool talkedToSeagull;		// Have we talked to the Seagull after completing their game?
		public bool talkedToPenguin;		// Have we talked to the Penguin for the first time?
		public bool staircaseUnlocked;		// Have we talked to the Penguin after finishing all minigames?
		public ScreenSide exitSide;			// Which side of the screen did we use to leave the last scene?

		// Side of the screen to enter in the next scene (opposite of exitSide)
		public ScreenSide enterSide {
			get { return exitSide == ScreenSide.LEFT ? ScreenSide.RIGHT : ScreenSide.LEFT; }
		}

		// Have all three minigames been completed?
		public bool allGamesComplete {
			get { return ostrichGameComplete && peacockGameComplete && seagullGameComplete; }
		}

		// Private constructor
		private GlobalState()
		{
			ostrichGameComplete = false;
			peacockGameComplete = false;
			seagullGameComplete = false;
			talkedToSeagull = false;
			talkedToPenguin = false;
			staircaseUnlocked = false;
		}
	}
}
