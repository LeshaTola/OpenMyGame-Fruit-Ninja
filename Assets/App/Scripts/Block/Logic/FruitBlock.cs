using Slicing.SliceStrategy;
using UnityEngine;

namespace Blocks.Logic
{
	public class FruitBlock : IBlock
	{
		public FruitBlock(ISliceStrategy sliceStrategy)
		{
			SliceStrategy = sliceStrategy;
		}

		public ISliceStrategy SliceStrategy { get; private set; }

		public void Slice(Vector2 delta)
		{
			SliceStrategy.Slice(delta);
		}
	}
}
