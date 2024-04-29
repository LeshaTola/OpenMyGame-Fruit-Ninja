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
				float yEdgePosition = block.transform.position.y + block.Collider.Radius;
				float leftXEdgePosition = block.transform.position.x + block.Collider.Radius;
				float rightXEdgePosition = block.transform.position.x - block.Collider.Radius;

				if (yEdgePosition < -mainCamera.orthographicSize)
				{
					blocksToDestroy.Add(block);
				}
				if (leftXEdgePosition < -mainCamera.orthographicSize * mainCamera.aspect || rightXEdgePosition > mainCamera.orthographicSize * mainCamera.aspect)
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
