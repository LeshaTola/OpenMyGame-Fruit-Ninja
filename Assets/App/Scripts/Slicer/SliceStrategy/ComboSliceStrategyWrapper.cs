using Blocks;
using Slicing.Combo;
using UnityEngine;

namespace Slicing.SliceStrategy
{
	public class ComboSliceStrategyWrapper : BaseSliceStrategyWrapper
	{
		private ComboController comboController;

		public ComboSliceStrategyWrapper(ISliceStrategy sliceStrategy, Block block, ComboController comboController) : base(sliceStrategy, block)
		{
			this.comboController = comboController;
		}

		public override void Slice(Vector2 delta)
		{
			base.Slice(delta);
			comboController.AddCombo(block, block.Config.Score);
		}
	}
}
