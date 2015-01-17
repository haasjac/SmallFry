using UnityEngine;
using System.Collections;

namespace SpaceJam
{
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
