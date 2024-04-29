using Assets.App.Scripts.General;
using UnityEngine;

namespace Blocks.Configs.Component
{
	public class HalvesComponent : BasicComponent
	{
		[SerializeField] private Config halfConfig;
		[SerializeField] private float explosionForce;

		public override void Execute(Block block)
		{
			var rightVector = new Vector2(Mathf.Abs(block.SliceDirection.x), Mathf.Abs(block.SliceDirection.y));
			var rotationMultiplayer = 1;
			if (block.Visual.transform.rotation.eulerAngles.z < -90 && block.Visual.transform.rotation.eulerAngles.z > 90)
			{
				rotationMultiplayer = -1;
			}

			for (int i = 0; i < block.Config.HalfSprites.Count; i++)
			{
				var directionMultiplier = i % 2 == 0 ? 1 : -1;

				var half = Context.PoolsContainer.Blocks.Get();

				half.ResetBlock();
				half.Init(halfConfig, block.Config.HalfSprites[i], block.Config.Radius, Context);

				SetTransforms(block, rotationMultiplayer, directionMultiplier, half);
				PushHalf(block, rightVector, directionMultiplier, half);
			}
		}


		private void SetTransforms(Block block, int rotationMultiplayer, int directionMultiplier, Block half)
		{
			var halfOffset = block.Collider.Radius / 2 * directionMultiplier * rotationMultiplayer;
			Vector2 halfPosition = new(block.transform.position.x, block.transform.position.y + halfOffset);
			half.transform.position = halfPosition;

			half.Visual.transform.rotation = block.Visual.transform.rotation;
			half.Visual.transform.localScale = block.Visual.transform.localScale;
		}

		private void PushHalf(Block block, Vector2 rightVector, int directionMultiplier, Block half)
		{
			Vector2 halfDirection = Vector2.Perpendicular(rightVector).normalized * directionMultiplier;
			half.Movement.Push(halfDirection * explosionForce);
			half.Movement.Push(block.Movement.Velocity);
		}

	}
}
