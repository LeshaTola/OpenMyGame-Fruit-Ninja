namespace Blocks.Kill
{
	public abstract class BaseKillStrategyWrapper : IKillStrategy
	{
		protected IKillStrategy killStrategy;
		protected Block block;

		public BaseKillStrategyWrapper(IKillStrategy killStrategy, Block block)
		{
			this.killStrategy = killStrategy;
			this.block = block;
		}

		public virtual void Kill()
		{
			killStrategy.Kill();
		}
	}
}
