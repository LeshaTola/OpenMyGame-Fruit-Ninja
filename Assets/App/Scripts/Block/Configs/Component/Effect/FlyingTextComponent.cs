using Score;
using UnityEngine;

namespace Blocks.Configs.Component
{
	public class FlyingTextComponent : BasicComponent
	{
		[SerializeField] private string text;

		public override void Execute(Block block)
		{
			SliceTextUI sliceUI = Context.PoolsContainer.SliceUI.Get();

			sliceUI.transform.position = block.transform.position;
			sliceUI.transform.rotation = Quaternion.identity;

			sliceUI.SetText(text);
			sliceUI.Show();
		}
	}
}
