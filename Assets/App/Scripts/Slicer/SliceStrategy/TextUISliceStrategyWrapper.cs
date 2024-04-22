using Blocks;
using Score;
using UnityEngine;
using Utility;

namespace Slicing.SliceStrategy
{
	public class TextUISliceStrategyWrapper : BaseSliceStrategyWrapper
	{
		private ObjectPool<SliceTextUI> textUIPool;
		private string text;

		public TextUISliceStrategyWrapper(ISliceStrategy strategy, Block block, ObjectPool<SliceTextUI> textUIPool, string text) : base(strategy, block)
		{
			this.textUIPool = textUIPool;
			this.text = text;
		}

		public override void Slice(Vector2 delta)
		{
			base.Slice(delta);
			SliceTextUI sliceUI = textUIPool.Get();

			sliceUI.transform.position = block.transform.position;
			sliceUI.transform.rotation = Quaternion.identity;

			sliceUI.SetText(text);
			sliceUI.Show();
		}
	}
}