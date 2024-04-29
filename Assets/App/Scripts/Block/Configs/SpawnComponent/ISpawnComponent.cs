using Assets.App.Scripts.General;

namespace Blocks.Configs.SpawnComponent
{
	public interface ISpawnComponent
	{
		public void Init(Context context, Block block);
		public void Start();
	}
}
