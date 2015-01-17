using UnityEngine;
using System.Collections;

namespace SpaceJam
{
	public abstract class Actor
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
		public override string GetName() { return "Benedict Cumberbatch"; }
		public override Sprite GetIcon() { return Resources.Load<Sprite>("Sprites/cumberbatch"); }
		public override string GetNextLine() { return "I have nothing to say."; }
	}
}
