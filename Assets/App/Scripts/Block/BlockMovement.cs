using UnityEngine;

namespace Block
{
	public class BlockMovement : MonoBehaviour
	{
		private const float GRAVITY = -9.8f;

		private Vector2 velocity;

		private void Update()
		{
			if (transform.position.y < -Camera.main.orthographicSize)
			{
				Destroy(gameObject);
			}

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
	}
}