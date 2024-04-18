using Blocks;
using UnityEngine;
using Utility;

namespace Slicing.SliceStrategy
{
	public class HalvesSliceStrategyWrapper : BaseSliceStrategyWrapper
	{
		private ObjectPool<Block> halvesPool;
		private float explosionForce;

		public HalvesSliceStrategyWrapper
			(
				ISliceStrategy sliceStrategy,
				Block block,
				ObjectPool<Block> halvesPool,
				float explosionForce
			) : base(sliceStrategy, block)
		{
			this.halvesPool = halvesPool;
			this.explosionForce = explosionForce;
			this.explosionForce = explosionForce;
		}

		public override void Slice(Vector2 delta)
		{
			base.Slice(delta);

			for (int i = 0; i < block.Config.HalfSprites.Count; i++)
			{
				var half = halvesPool.Get();

				half.transform.position = block.transform.position;
				half.transform.rotation = block.transform.rotation;
				half.transform.localScale = block.transform.localScale;

				half.ResetBlock(
					block.Config.HalfSprites[i],
					block.Collider.Radius
				);
				Vector2 halfDirection = Vector2.Perpendicular(delta).normalized * (i % 2 == 0 ? 1 : -1);
				half.Movement.Push(halfDirection * explosionForce);
				half.Movement.Push(block.Movement.Velocity);
			}
		}
	}
}
