using Blocks.Kill;
using Slicing.SliceStrategy;
using UnityEngine;

namespace Blocks.Logic
{
	public class BaseBlock : IBlock
	{
		public ISliceStrategy SliceStrategy { get; private set; }
		public IKillStrategy KillStrategy { get; private set; }

		public BaseBlock(ISliceStrategy sliceStrategy, IKillStrategy killStrategy)
		{
			SliceStrategy = sliceStrategy;
			KillStrategy = killStrategy;
		}

		public void Slice(Vector2 delta)
		{
			SliceStrategy.Slice(delta);
		}

		public void Kill()
		{
			KillStrategy.Kill();
		}
	}
}
