using Physics;
using System;
using UnityEngine;

namespace Blocks
{
	public class Block : MonoBehaviour
	{
		[SerializeField] private Config config;
		[SerializeField] private Visual visual;
		[SerializeField] private Movement movement;
		[SerializeField] private MyCollider myCollider;


		private Action destroyAction;
		private Camera mainCamera;

		public Config Config { get => config; }
		public Visual Visual { get => visual; }
		public Movement Movement { get => movement; }
		public MyCollider Collider { get => myCollider; }
		public Camera MainCamera { get => mainCamera; }

		public void Init(Config config, Action destroyAction, Camera mainCamera)
		{
			this.config = config;
			Init(config.BlockSprite, config.Radius, destroyAction, mainCamera);
		}

		public void Init(Sprite sprite, float radius, Action destroyAction, Camera mainCamera)
		{
			this.destroyAction = destroyAction;
			this.mainCamera = mainCamera;

			visual.Init(sprite);

			myCollider.Radius = radius;
		}

		private void Update()
		{
			ValidateBoundaries();
		}

		public void ResetBlock()
		{
			visual.RestartAnimation();
			movement.Reset();
		}

		public void DestroyYourself()
		{
			destroyAction();
		}

		private void ValidateBoundaries()
		{
			if (transform.position.y + myCollider.Radius < -mainCamera.orthographicSize)
			{
				DestroyYourself();
			}
		}
	}
}
