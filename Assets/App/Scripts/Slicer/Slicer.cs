﻿using Blocks;
using General;
using Input;
using Spawn;
using System.Collections.Generic;
using UnityEngine;

namespace Slicing
{
	public class Slicer : MonoBehaviour
	{
		[SerializeField] private Spawner spawner;
		[SerializeField] private float minSpeed;
		[SerializeField] private float explosionForce;

		[SerializeField] private ObjectPoolsContainer poolsContainer;

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
				block.Slice(deltaVector);
			}
		}

		private List<Block> GetSlicedBlocks(Delta delta)
		{
			List<Block> slicedBlocks = new List<Block>();
			foreach (var block in poolsContainer.Fruits.Active)
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