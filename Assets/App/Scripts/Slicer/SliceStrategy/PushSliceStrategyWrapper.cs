using Blocks;
using UnityEngine;
using Utility;

namespace Slicing.SliceStrategy
{
	public class PushSliceStrategyWrapper : BaseSliceStrategyWrapper
	{
		private ObjectPool<Block> blocksPool;
		private float force;
		private float influenceRadius;

		public PushSliceStrategyWrapper(ISliceStrategy sliceStrategy, Block block, ObjectPool<Block> blocksPool, float influenceRadius, float force) : base(sliceStrategy, block)
		{
			this.blocksPool = blocksPool;
			this.influenceRadius = influenceRadius;
			this.force = force;
		}

		public override void Slice(Vector2 delta)
		{
			base.Slice(delta);
			foreach (var otherBlock in blocksPool.Active)
			{
				Vector2 pushDirection = otherBlock.transform.position - block.transform.position;
				if (pushDirection.magnitude < influenceRadius)
				{
					float forceModifier = (influenceRadius - pushDirection.magnitude) / influenceRadius;
					otherBlock.Movement.Push(pushDirection.normalized * force * forceModifier);
				}
			}
		}
	}
}
