namespace Blocks.Factory
{
	public interface IBlockFactory
	{
		public Block GetBlock(Config config);
	}
}
