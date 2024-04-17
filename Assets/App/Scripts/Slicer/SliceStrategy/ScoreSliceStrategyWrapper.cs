using Blocks;
using Score;
using UnityEngine;
using Utility;

namespace Slicing.SliceStrategy
{
	public class ScoreSliceStrategyWrapper : BaseSliceStrategyWrapper
	{
		private ObjectPool<SliceScoreUI> sliceScorePool;
		private float explosionForce;
		private ScoreController scoreController;

		public ScoreSliceStrategyWrapper
			(
				ISliceStrategy sliceStrategy,
				Block block,
				ObjectPool<SliceScoreUI> sliceScorePool,
				ScoreController scoreController,
				float explosionForce
			) : base(sliceStrategy, block)
		{
			this.sliceScorePool = sliceScorePool;
			this.scoreController = scoreController;
			this.explosionForce = explosionForce;
		}

		public override void Slice(Vector2 delta)
		{
			base.Slice(delta);
			SliceScoreUI sliceUI = sliceScorePool.Get();

			sliceUI.transform.position = block.transform.position;
			sliceUI.transform.rotation = Quaternion.identity;

			sliceUI.SetScore(block.Config.Score);
			scoreController.AddScore(block.Config.Score);

			sliceUI.Movement.Push(delta.normalized * explosionForce);
		}
	}
}
