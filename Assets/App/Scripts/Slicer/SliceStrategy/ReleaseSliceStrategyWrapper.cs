using Blocks;
using UnityEngine;
using Utility;

namespace Slicing.SliceStrategy
{
	public class ReleaseSliceStrategyWrapper : BaseSliceStrategyWrapper
	{
		private ObjectPool<Block> blocksPool;
		public ReleaseSliceStrategyWrapper(ISliceStrategy sliceStrategy, Block block, ObjectPool<Block> blocksPool) : base(sliceStrategy, block)
		{
			this.blocksPool = blocksPool;
		}

		public override void Slice(Vector2 delta)
		{
			base.Slice(delta);
			blocksPool.Release(block);
		}
	}
}
