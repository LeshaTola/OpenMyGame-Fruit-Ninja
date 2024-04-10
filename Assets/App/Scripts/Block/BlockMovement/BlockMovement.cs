using UnityEngine;

namespace Block
{
	public class BlockMovement : IMovement
	{
		private const float GRAVITY = -9.8f;

		private Block block;
		private Vector2 velocity;

		public Vector2 Velocity { get => velocity; }

		public BlockMovement(Block block)
		{
			this.block = block;
		}

		public void Push(Vector2 value)
		{
			velocity += value;
		}

		public void CalculateVelocity()
		{
			velocity.y += GRAVITY * Time.deltaTime;
		}

		public void Move()
		{
			Vector2 currentPosition = block.transform.position;
			block.transform.position = Vector2.Lerp(currentPosition, currentPosition + velocity, Time.deltaTime);
		}

		public void ValidateBoundaries()
		{
			if (block.transform.position.y + block.Radius < -Camera.main.orthographicSize)
			{
				GameObject.Destroy(block.gameObject);
			}
		}
	}
}