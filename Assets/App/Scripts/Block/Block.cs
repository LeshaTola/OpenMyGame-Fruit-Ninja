using General;
using Physics;
using Slicing.SliceStrategy;
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
		private ISliceStrategy sliceStrategy;
		private ObjectPoolsContainer objectPools;

		public Config Config { get => config; }
		public Visual Visual { get => visual; }
		public Movement Movement { get => movement; }
		public MyCollider Collider { get => myCollider; }

		public void Init(Config config, Action destroyAction, ObjectPoolsContainer objectPools)
		{
			this.config = config;
			this.objectPools = objectPools;

			var halvesStrategy = new HalvesSliceStrategyWrapper(new NoSliceStrategy(), this, objectPools.Halves);
			var effectStrategy = new EffectSliceStrategyWrapper(halvesStrategy, this, objectPools.Effects);
			var particleStrategy = new ParticleSliceStrategyWrapper(effectStrategy, this, objectPools.Particles);
			var destroyStrategy = new DestroySliceStrategyWrapper(particleStrategy, this);
			sliceStrategy = destroyStrategy;

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
			Init(config, destroyAction, objectPools);
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

		public void Slice(Vector2 delta)
		{
			sliceStrategy.Slice(delta);
		}
	}
}
