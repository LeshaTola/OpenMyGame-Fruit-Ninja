using Blocks.Logic;
using Physics;
using UnityEngine;

namespace Blocks
{
	public class Block : MonoBehaviour, IBlock
	{
		[SerializeField] private Config config;
		[SerializeField] private Visual visual;
		[SerializeField] private Movement movement;
		[SerializeField] private MyCollider myCollider;

		private IBlock blockLogic;

		public Config Config { get => config; }
		public Visual Visual { get => visual; }
		public Movement Movement { get => movement; }
		public MyCollider Collider { get => myCollider; }

		public void Init(Config config, IBlock blockLogic)
		{
			this.config = config;

			Init(config.BlockSprite, config.Radius, blockLogic);
		}

		public void Init(Sprite sprite, float radius, IBlock blockLogic)
		{
			this.blockLogic = blockLogic;

			visual.Init(sprite);
			myCollider.Radius = radius;
		}

		public void ResetBlock()
		{
			visual.RestartAnimation();
			movement.Reset();
		}

		public void Slice(Vector2 delta)
		{
			blockLogic.Slice(delta);
		}

		public void Kill()
		{
			blockLogic.Kill();
		}
	}
}
