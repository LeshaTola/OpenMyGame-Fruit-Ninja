using System;
using UnityEngine;

namespace Input
{
	public interface IPlayerInput
	{
		public Delta GetInputDelta();
	}

	public struct Delta
	{
		public Vector2 prevPos;
		public Vector2 currPos;

		public override bool Equals(object obj)
		{
			return obj is Delta delta &&
				   prevPos.Equals(delta.prevPos) &&
				   currPos.Equals(delta.currPos);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(prevPos, currPos);
		}
	}
}
