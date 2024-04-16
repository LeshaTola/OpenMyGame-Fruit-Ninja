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

		public Config Config { get => config; }
		public Visual Visual { get => visual; }
		public Movement Movement { get => movement; }
		public MyCollider Collider { get => myCollider; }

		public void Init(Config config, Action destroyAction)
		{
			this.config = config;
			Init(config.BlockSprite, config.Radius, destroyAction);
		}

		public void Init(Sprite sprite, float radius, Action destroyAction)
		{
			this.destroyAction = destroyAction;

			visual.Init(sprite);
			myCollider.Radius = radius;
		}

		public void ResetBlock(Config config)
		{
			ResetBlock();
			Init(config, destroyAction);
		}

		public void ResetBlock(Sprite sprite, float radius)
		{
			ResetBlock();
			Init(sprite, radius, destroyAction);
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
	}
}
