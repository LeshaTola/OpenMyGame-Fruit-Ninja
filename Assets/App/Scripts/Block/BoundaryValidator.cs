using General;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Blocks
{
	public class BoundaryValidator : MonoBehaviour
	{
		[SerializeField] private Camera mainCamera;
		[SerializeField] private ObjectPoolsContainer poolsContainer;

		public event Action OnBlockDestroy;

		private void Update()
		{
			ValidateBoundaries();
		}

		private void ValidateBoundaries()
		{
			ValidateBlocks();
		}

		private void ValidateBlocks()
		{
			List<Block> blocksToDestroy = new List<Block>();
			foreach (var block in poolsContainer.Blocks.Active)
			{
				if (block.transform.position.y + block.Collider.Radius < -mainCamera.orthographicSize)
				{
					blocksToDestroy.Add(block);
				}
			}

			foreach (var block in blocksToDestroy)
			{
				block.Kill();
				OnBlockDestroy?.Invoke();
			}
		}
	}
}
