using UnityEngine;
using System.Collections;

namespace SpaceJam
{
	// TODO: Change this to an interface
	public abstract class Actor : MonoBehaviour
	{
		// Returns the name of this actor
		public abstract string GetName();

		// Returns this actor's icon filename
		public abstract Sprite GetIcon();

		// Returns the next line of dialogue this actor should say
		public abstract string GetNextLine();
	}

	public class DefaultActor : Actor
	{
		int state = 0;

		public override string GetName() { return "Benedict Cumberbatch"; }

		public override Sprite GetIcon() { return Resources.Load<Sprite>("Sprites/cumberbatch"); }

		public override string GetNextLine()
		{
			string line = null;

			switch (state)
			{
			case 0:
				state = 1;
				line = "I have nothing to say.";
				break;
			case 1:
				state = 0;
				break;
			}

			return line;
		}
	}
}
