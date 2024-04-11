using UnityEngine;

namespace Input
{
	public interface IPlayerInput
	{
		public Delta GetInputDelta();

		public class Delta
		{
			public Vector2 prevPos;
			public Vector2 currPos;
		}
	}
}
