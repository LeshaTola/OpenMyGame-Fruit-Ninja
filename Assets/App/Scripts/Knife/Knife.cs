using Block;
using Input;
using Spawn;
using System.Collections.Generic;
using UnityEngine;

namespace Knife
{
	public class Knife : MonoBehaviour
	{
		[SerializeField] private Spawner spawner;
		[SerializeField] private float minSpeed;

		[SerializeField] private Half halfTemplate;
		[SerializeField] private Effect effectTemplate;

		private IPlayerInput playerInput;

		public void Init(IPlayerInput playerInput)
		{
			this.playerInput = playerInput;
		}

		private void Update()
		{
			Slice();
		}

		private void Slice()
		{
			var delta = playerInput.GetInputDelta();
			Vector2 deltaVector = delta.currPos - delta.prevPos;
			if (delta.Equals(default) || !IsValid(deltaVector))
			{
				return;
			}

			transform.position = delta.currPos;
			List<Block.Block> slicedBlocks = GetSlicedBlocks(delta);
			foreach (var block in slicedBlocks)
			{
				ProcessHalves(deltaVector, block);
				ProcessEffect(block);

				block.DestroyYourself();
			}
		}

		private void ProcessHalves(Vector2 deltaVector, Block.Block block)
		{
			float speed = 10f;

			for (int i = 0; i < block.Config.HalfSprites.Count; i++)
			{
				var half = Instantiate(halfTemplate, block.transform.position, Quaternion.identity);
				half.Visual.Init(block.Config.HalfSprites[i]);

				Vector2 halfDirection = Vector2.Perpendicular(deltaVector).normalized * (i % 2 == 0 ? 1 : -1);
				half.Movement.Push(halfDirection * speed);
			}
		}

		private void ProcessEffect(Block.Block block)
		{
			var effect = Instantiate(effectTemplate, block.transform.position, Quaternion.identity);
			effect.Init(block.Config.SliceEffect);
			effect.PlayAnimation();
		}

		private List<Block.Block> GetSlicedBlocks(Delta delta)
		{
			List<Block.Block> slicedBlocks = new List<Block.Block>();
			foreach (var block in spawner.BlocksPool.Active)
			{
				float distance = MinimumDistance(delta.prevPos, delta.currPos, block.transform.position);
				if (distance <= block.Collider.Radius)
				{
					slicedBlocks.Add(block);
				}
			}
			return slicedBlocks;
		}

		private bool IsValid(Vector2 deltaVector)
		{
			return deltaVector.magnitude >= minSpeed;
		}

		public float MinimumDistance(Vector2 start, Vector2 end, Vector2 target)
		{
			float length = (end - start).sqrMagnitude;
			if (length == 0.0f)
				return Vector2.Distance(target, start);

			float t = Mathf.Clamp01(Vector2.Dot(target - start, end - start) / length);
			Vector2 projection = start + t * (end - start);
			return Vector2.Distance(target, projection);
		}
	}
}