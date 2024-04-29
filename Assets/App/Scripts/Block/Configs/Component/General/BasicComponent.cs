using Assets.App.Scripts.General;

namespace Blocks.Configs.Component
{
	public abstract class BasicComponent : IComponent
	{
		protected Context Context;

		public void Init(Context context)
		{
			Context = context;
		}

		public abstract void Execute(Block block);

	}
}
