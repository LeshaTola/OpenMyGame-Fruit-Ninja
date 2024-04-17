using Blocks;
using UnityEngine;

namespace Slicing.SliceStrategy
{
	public class DestroySliceStrategyWrapper : BaseSliceStrategyWrapper
	{
		public DestroySliceStrategyWrapper(ISliceStrategy sliceStrategy, Block block) : base(sliceStrategy, block)
		{
		}

		public override void Slice(Vector2 delta)
		{
			base.Slice(delta);
			block.DestroyYourself();
		}
	}
}
