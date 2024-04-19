using Health;

namespace Blocks.Kill
{
	public class ReduceHealthKillStrategyWrapper : BaseKillStrategyWrapper
	{
		private HealthController healthController;
		private int value;

		public ReduceHealthKillStrategyWrapper(
			IKillStrategy killStrategy,
			Block block,
			HealthController healthController,
			int value) : base(killStrategy, block)
		{
			this.healthController = healthController;
			this.value = value;
		}

		public override void Kill()
		{
			base.Kill();
			healthController.ReduceHealth(value);
		}
	}
}
