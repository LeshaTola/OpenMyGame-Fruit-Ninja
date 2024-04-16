using General;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Blocks
{
	public class DeathLine : MonoBehaviour
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
			List<Block> blocksToDestroy = new List<Block>();
			foreach (var block in poolsContainer.Fruits.Active)
			{
				if (block.transform.position.y + block.Collider.Radius < -mainCamera.orthographicSize)
				{
					blocksToDestroy.Add(block);
				}
			}

			foreach (var block in blocksToDestroy)
			{
				block.DestroyYourself();
				OnBlockDestroy?.Invoke();
			}

			blocksToDestroy = new List<Block>();
			foreach (var block in poolsContainer.Halves.Active)
			{
				if (block.transform.position.y + block.Collider.Radius < -mainCamera.orthographicSize)
				{
					blocksToDestroy.Add(block);
				}
			}

			foreach (var block in blocksToDestroy)
			{
				block.DestroyYourself();
			}
		}
	}
}
