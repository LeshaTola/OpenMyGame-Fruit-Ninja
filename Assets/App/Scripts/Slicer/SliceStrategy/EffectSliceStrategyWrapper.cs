using Blocks;
using UnityEngine;
using Utility;

namespace Slicing.SliceStrategy
{
	public class EffectSliceStrategyWrapper : BaseSliceStrategyWrapper
	{
		private ObjectPool<Effect> effectPool;

		public EffectSliceStrategyWrapper(ISliceStrategy sliceStrategy, Block block, ObjectPool<Effect> effectPool) : base(sliceStrategy, block)
		{
			this.effectPool = effectPool;
		}

		public override void Slice(Vector2 delta)
		{
			base.Slice(delta);

			var effect = effectPool.Get();
			effect.transform.position = block.transform.position;
			effect.transform.rotation = Quaternion.identity;

			effect.Init(block.Config.SliceEffect);
			effect.PlayAnimation();
		}
	}
}
