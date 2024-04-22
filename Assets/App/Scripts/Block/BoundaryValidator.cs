using General;
using Score;
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
			ValidateSliceUI();
		}

		private void ValidateSliceUI()
		{
			List<SliceTextUI> UIToDestroy = new();
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
