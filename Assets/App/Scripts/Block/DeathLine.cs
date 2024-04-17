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
			ValidateBlocks();
			ValidateHalves();
			ValidateSliceUI();
		}

		private void ValidateSliceUI()
		{
			List<SliceScoreUI> UIToDestroy = new();
			foreach (var UI in poolsContainer.SliceUI.Active)
			{
				if (UI.transform.position.y + UI.transform.localScale.y < -mainCamera.orthographicSize)
				{
					UIToDestroy.Add(UI);
				}
			}

			foreach (var UI in UIToDestroy)
			{
				poolsContainer.SliceUI.Release(UI);
			}
		}

		private void ValidateBlocks()
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
		}

		private void ValidateHalves()
		{
			List<Block> blocksToDestroy = new List<Block>();
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
