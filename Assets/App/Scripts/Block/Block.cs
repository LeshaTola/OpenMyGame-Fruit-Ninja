using Physics;
using System;
using UnityEngine;

namespace Block
{
	public class Block : MonoBehaviour
	{
		public event Action OnDestroy;

		[SerializeField] private BlockConfig config;
		[SerializeField] private BlockAnimation blockAnimation;
		[SerializeField] private Movement movement;
		[SerializeField] private Physics.Collider circleCollider;

		public Movement Movement { get => movement; }
		public BlockAnimation BlockAnimation { get => blockAnimation; }
		public Physics.Collider Collider { get => circleCollider; }
		public BlockConfig Config { get => config; }

		private void Update()
		{
			ValidateBoundaries();
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
