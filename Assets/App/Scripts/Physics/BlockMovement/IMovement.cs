using UnityEngine;

namespace Physics
{
	public interface IMovement
	{
		public Vector2 Velocity { get; }

		public void CalculateVelocity();
		public void Move();

		public void Push(float x = 0f, float y = 0f)
		{
			Push(new Vector2(x, y));
		}

		public void Push(Vector2 value);

		public void Reset();

	}
}
