using Blocks;
using Blocks.Factory;
using UnityEngine;

namespace Slicing.SliceStrategy
{
	public class HalvesSliceStrategyWrapper : BaseSliceStrategyWrapper
	{
		private IBlockFactory blockFactory;
		private float explosionForce;

		public HalvesSliceStrategyWrapper
			(
				ISliceStrategy sliceStrategy,
				Block block,
				IBlockFactory blockFactory,
				float explosionForce
			) : base(sliceStrategy, block)
		{
			this.blockFactory = blockFactory;
			this.explosionForce = explosionForce;
			this.explosionForce = explosionForce;
		}

		public override void Slice(Vector2 delta)
		{
			base.Slice(delta);
			var rightVector = new Vector2(Mathf.Abs(delta.x), Mathf.Abs(delta.y));
			var rotationMultiplayer = 1;
			if (block.Visual.transform.rotation.eulerAngles.z < -90 && block.Visual.transform.rotation.eulerAngles.z > 90)
			{
				rotationMultiplayer = -1;
			}

			for (int i = 0; i < block.Config.HalfSprites.Count; i++)
			{
				var directionMultiplier = i % 2 == 0 ? 1 : -1;

				var half = blockFactory.GetHalf(block.Config.HalfSprites[i], block.Collider.Radius);
				SetTransforms(rotationMultiplayer, directionMultiplier, half);
				PushHalf(rightVector, directionMultiplier, half);
			}
		}

		private void SetTransforms(int rotationMultiplayer, int directionMultiplier, Block half)
		{
			var halfOffset = block.Collider.Radius / 2 * directionMultiplier * rotationMultiplayer;
			Vector2 halfPosition = new(block.transform.position.x, block.transform.position.y + halfOffset);
			half.transform.position = halfPosition;

			half.Visual.transform.rotation = block.Visual.transform.rotation;
			half.Visual.transform.localScale = block.Visual.transform.localScale;
		}

		private void PushHalf(Vector2 rightVector, int directionMultiplier, Block half)
		{
			Vector2 halfDirection = Vector2.Perpendicular(rightVector).normalized * directionMultiplier;
			half.Movement.Push(halfDirection * explosionForce);
			half.Movement.Push(block.Movement.Velocity);
		}
	}
}
