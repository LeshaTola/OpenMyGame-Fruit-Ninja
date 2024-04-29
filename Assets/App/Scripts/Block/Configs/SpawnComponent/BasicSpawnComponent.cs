using Assets.App.Scripts.General;

namespace Blocks.Configs.SpawnComponent
{
	public abstract class BasicSpawnComponent : ISpawnComponent
	{
		protected Context Context;
		protected Block Block;

		public virtual void Init(Context context, Block block)
		{
			Context = context;
			Block = block;
		}

		public abstract void Start();
	}
}
