using Blocks;
using Score;
using UnityEngine;

namespace Slicing.SliceStrategy
{
	public class ScoreSliceStrategyWrapper : BaseSliceStrategyWrapper
	{
		private ScoreController scoreController;

		public ScoreSliceStrategyWrapper
			(
				ISliceStrategy sliceStrategy,
				Block block,
				ScoreController scoreController
			) : base(sliceStrategy, block)
		{
			this.scoreController = scoreController;
		}

		public override void Slice(Vector2 delta)
		{
			base.Slice(delta);
			scoreController.AddScore(block.Config.Score);
		}
	}
}
