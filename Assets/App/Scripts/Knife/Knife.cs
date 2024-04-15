using Blocks;
using Input;
using Spawn;
using System.Collections.Generic;
using UnityEngine;

namespace Slicing
{
	public class Knife : MonoBehaviour
	{
		[SerializeField] private Spawner spawner;
		[SerializeField] private float minSpeed;
		[SerializeField] private float explosionForce;

		[SerializeField] private Block blockTemplate;
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
			List<Block> slicedBlocks = GetSlicedBlocks(delta);
			foreach (var block in slicedBlocks)
			{
				ProcessHalves(deltaVector, block);
				ProcessEffect(block);
				ProcessParticles(block);

				block.DestroyYourself();
			}
		}

		private void ProcessHalves(Vector2 deltaVector, Block block)
		{
			for (int i = 0; i < block.Config.HalfSprites.Count; i++)
			{
				var newBlock = Instantiate(blockTemplate, block.transform.position, Quaternion.identity);

				newBlock.transform.localScale = block.transform.localScale;
				newBlock.Init(
					block.Config.HalfSprites[i],
					block.Collider.Radius,
					() => Destroy(newBlock.gameObject),
					block.MainCamera
				);
				newBlock.ResetBlock();

				Vector2 halfDirection = Vector2.Perpendicular(deltaVector).normalized * (i % 2 == 0 ? 1 : -1);
				newBlock.Movement.Push(halfDirection * explosionForce);
			}
		}

		private void ProcessEffect(Block block)
		{
			var effect = Instantiate(effectTemplate, block.transform.position, Quaternion.identity);
			effect.Init(block.Config.SliceEffect);
			effect.PlayAnimation();
		}

		private static void ProcessParticles(Block block)
		{
			ParticleSystem particles = Instantiate(block.Config.JuiceParticle, block.transform.position, Quaternion.identity);
			ParticleSystem.MainModule particlesMain = particles.main;
			particlesMain.startColor = block.Config.JuiceColor;
			particles.Play();
		}

		private List<Block> GetSlicedBlocks(Delta delta)
		{
			List<Block> slicedBlocks = new List<Block>();
			foreach (var block in spawner.BlocksPool.Active)
			{
				float distance = GetMinimumDistance(delta.prevPos, delta.currPos, block.transform.position);
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

		private float GetMinimumDistance(Vector2 start, Vector2 end, Vector2 target)
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