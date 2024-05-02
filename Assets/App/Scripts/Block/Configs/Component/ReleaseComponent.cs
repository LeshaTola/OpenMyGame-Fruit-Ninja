using System;

namespace Blocks.Configs.Component
{
	public class ReleaseComponent : BasicComponent
	{

		private Action additionalAction;

		public override void Execute(Block block)
		{
			additionalAction?.Invoke();
			Context.PoolsContainer.Blocks.Release(block);
		}

		public void SetAdditionalAction(Action action)
		{
			additionalAction = action;
		}

		public void ClearAdditionalAction()
		{
			additionalAction = null;
		}
	}
}
