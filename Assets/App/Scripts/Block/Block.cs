using Physics;
using System;
using UnityEngine;

namespace Block
{
	public class Block : MonoBehaviour
	{
		public event Action OnDestroy;

		[SerializeField] private BlockAnimation blockAnimation;
		[SerializeField] private BlockMovement movement;
		[SerializeField] private Physics.Collider circleCollider;

		public IMovement Movement { get => movement; }
		public BlockAnimation BlockAnimation { get => blockAnimation; }
		public Physics.Collider Collider { get => circleCollider; }

		private void Update()
		{
			ValidateBoundaries();
			movement.CalculateVelocity();
			movement.Move();
		}

		private void ValidateBoundaries()
		{
			if (transform.position.y + circleCollider.Radius < -Camera.main.orthographicSize)
			{
				DestroyYourself();
			}
		}

		public void DestroyYourself()
		{
			OnDestroy?.Invoke();
		}
	}
}
