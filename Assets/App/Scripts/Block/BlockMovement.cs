using UnityEngine;

namespace Block
{
	[RequireComponent(typeof(Block))]
	public class BlockMovement : MonoBehaviour
	{
		private const float GRAVITY = -9.8f;

		[SerializeField] private Block block;

		private Vector2 velocity;

		private void Update()
		{
			ValidateBoundaries();
			CalculateVelocity();
			Move();
		}

		public void Push(float x = 0f, float y = 0f)
		{
			Push(new Vector2(x, y));
		}

		public void Push(Vector2 value)
		{
			velocity += value;
		}

		private void CalculateVelocity()
		{
			velocity.y += GRAVITY * Time.deltaTime;
		}

		private void Move()
		{
			transform.position = Vector3.Lerp(transform.position, transform.position + (Vector3)velocity, Time.deltaTime);
		}

		private void ValidateBoundaries()
		{
			if (transform.position.y + block.Radius < -Camera.main.orthographicSize)
			{
				Destroy(gameObject);
			}
		}
	}
}