using Blocks;
using Health;
using UnityEngine;

namespace Slicing.SliceStrategy
{
	public class ReduceHealthSliceStrategyWrapper : BaseSliceStrategyWrapper
	{
		private HealthController healthController;
		private int value;

		public ReduceHealthSliceStrategyWrapper(
			ISliceStrategy killStrategy,
			Block block,
			HealthController healthController,
			int value) : base(killStrategy, block)
		{
			this.healthController = healthController;
			this.value = value;
		}

		public override void Slice(Vector2 delta)
		{
			base.Slice(delta);
			healthController.ReduceHealth(value);
		}
	}
}
