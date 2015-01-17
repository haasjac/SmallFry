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
}
