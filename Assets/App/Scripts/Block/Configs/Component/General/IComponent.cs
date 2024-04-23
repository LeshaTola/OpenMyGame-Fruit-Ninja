using Assets.App.Scripts.General;

namespace Blocks.Configs.Component
{
	public interface IComponent
	{
		public void Init(Context context);
		public void Execute(Block block);
	}
}
