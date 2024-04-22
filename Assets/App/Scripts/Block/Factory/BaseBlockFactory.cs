using Assets.App.Scripts.General;

namespace Blocks.Factory
{
	public class BaseBlockFactory : IBlockFactory
	{
		private Context context;

		public BaseBlockFactory(Context context)
		{
			this.context = context;
		}

		public Block GetBlock(Config config)
		{
			var block = context.PoolsContainer.Blocks.Get();

			block.ResetBlock();
			block.Init(config, context);
			return block;
		}
	}
}
