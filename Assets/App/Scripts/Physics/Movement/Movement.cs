using UnityEngine;

namespace Physics
{
	public class Movement : MonoBehaviour, IMovement
	{
		private const float GRAVITY = -9.8f;

		private Vector2 velocity;
		private float speed = 1f;

		public Vector2 Velocity { get => velocity; }
		public float Speed { get => speed; set => speed = value; }

		private void Update()
		{
			CalculateVelocity();
			Move();
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
			Vector2 currentPosition = transform.position;
			transform.position = Vector2.Lerp(currentPosition, currentPosition + speed * velocity, Time.deltaTime);
		}

		public void Reset()
		{
			velocity = Vector2.zero;
		}
	}
}