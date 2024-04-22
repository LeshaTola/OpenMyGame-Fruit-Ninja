using UnityEngine;

namespace Blocks.Configs.Component
{
	[CreateAssetMenu(fileName = "ReleaseComponent", menuName = "Configs/Blocks/Components/ReleaseComponent")]
	public class ReleaseComponent : BasicComponent
	{
		public override void Execute(Block block)
		{
			Context.PoolsContainer.Blocks.Release(block);
		}
	}
}
