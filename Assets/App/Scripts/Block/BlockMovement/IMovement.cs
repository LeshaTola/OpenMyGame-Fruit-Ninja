using UnityEngine;

namespace Block
{
	public interface IMovement
	{
		public Vector2 Velocity { get; }

		public void CalculateVelocity();
		public void Move();
		public void ValidateBoundaries();

		public void Push(float x = 0f, float y = 0f)
		{
			Push(new Vector2(x, y));
		}

		public void Push(Vector2 value);

	}
}
