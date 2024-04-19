using Utility;

namespace Blocks.Kill
{
	public class ReleaseKillStrategyWrapper : BaseKillStrategyWrapper
	{
		private ObjectPool<Block> blocksPool;

		public ReleaseKillStrategyWrapper(IKillStrategy killStrategy, Block block, ObjectPool<Block> blocksPool) : base(killStrategy, block)
		{
			this.blocksPool = blocksPool;
		}

		public override void Kill()
		{
			base.Kill();
			blocksPool.Release(block);
		}
	}
}
