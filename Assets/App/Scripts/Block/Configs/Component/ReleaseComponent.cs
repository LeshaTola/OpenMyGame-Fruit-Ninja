using System;

namespace Blocks.Configs.Component
{
	public class ReleaseComponent : BasicComponent
	{
		public event Action OnRelease;

		public override void Execute(Block block)
		{
			OnRelease?.Invoke();
			Context.PoolsContainer.Blocks.Release(block);
		}
	}
}
