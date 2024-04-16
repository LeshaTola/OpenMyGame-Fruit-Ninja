using Blocks;
using UnityEngine;

namespace Slicing.SliceStrategy
{
	public abstract class BaseSliceStrategyWrapper : ISliceStrategy
	{
		protected ISliceStrategy sliceStrategy;
		protected Block block;

		public BaseSliceStrategyWrapper(ISliceStrategy sliceStrategy, Block block)
		{
			this.sliceStrategy = sliceStrategy;
			this.block = block;
		}

		public virtual void Slice(Vector2 delta)
		{
			sliceStrategy.Slice(delta);
		}
	}
}
