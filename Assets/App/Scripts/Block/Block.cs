using Physics;
using System;
using UnityEngine;

namespace Block
{
	public class Block : MonoBehaviour
	{
		public event Action OnDestroy;

		[SerializeField] private BlockConfig config;
		[SerializeField] private BlockVisual visual;
		[SerializeField] private BlockAnimation blockAnimation;
		[SerializeField] private Movement movement;
		[SerializeField] private Physics.Collider circleCollider;

		public BlockConfig Config { get => config; }
		public BlockVisual Visual { get => visual; set => visual = value; }
		public BlockAnimation BlockAnimation { get => blockAnimation; }
		public Movement Movement { get => movement; }
		public Physics.Collider Collider { get => circleCollider; }

		private void Update()
		{
			ValidateBoundaries();
		}

		public void Init(BlockConfig config)
		{
			this.config = config;

			Visual.Init(config.BlockSprite);
			circleCollider.Radius = config.Radius;
			movement.Reset();
			blockAnimation.Restart();
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
