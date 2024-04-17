using Blocks.Logic;
using Physics;
using System;
using UnityEngine;

namespace Blocks
{
	public class Block : MonoBehaviour, IBlock
	{
		[SerializeField] private Config config;
		[SerializeField] private Visual visual;
		[SerializeField] private Movement movement;
		[SerializeField] private MyCollider myCollider;

		private Action destroyAction;
		private IBlock blockLogic;

		public Config Config { get => config; }
		public Visual Visual { get => visual; }
		public Movement Movement { get => movement; }
		public MyCollider Collider { get => myCollider; }

		public void Init(Config config, Action destroyAction, IBlock blockLogic)
		{
			this.config = config;
			this.destroyAction = destroyAction;

			Init(config.BlockSprite, config.Radius, destroyAction, blockLogic);
		}

		public void Init(Sprite sprite, float radius, Action destroyAction, IBlock blockLogic)
		{
			this.destroyAction = destroyAction;
			this.blockLogic = blockLogic;

			visual.Init(sprite);
			myCollider.Radius = radius;
		}

		public void ResetBlock(Config config)
		{
			ResetBlock();
			Init(config, destroyAction, blockLogic);
		}

		public void ResetBlock(Sprite sprite, float radius)
		{
			ResetBlock();
			Init(sprite, radius, destroyAction, blockLogic);
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

		public void Slice(Vector2 delta)
		{
			blockLogic.Slice(delta);
		}
	}
}
