﻿using Blocks.Factory;
using General;
using Regions;
using Spawn.Progressor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Spawn
{
	public class Spawner : MonoBehaviour, IResettable
	{
		[SerializeField] private List<Region> regions;
		[SerializeField] private SpawnConfig config;
		[SerializeField] private Camera mainCamera;

		private IBlockFactory blockFactory;
		private IProgressor progressor;

		public IReadOnlyCollection<Region> Regions { get => regions; }

		public void Init(IProgressor progressor, IBlockFactory blockFactory)
		{
			this.progressor = progressor;
			this.blockFactory = blockFactory;

			progressor.Init(config, this);
		}

		public IEnumerator SpawnPack()
		{
			Region region = GetRegion();

			var fruitTimer = new WaitForSeconds(progressor.FruitCooldown);
			for (int i = 0; i < progressor.FruitCount; i++)
			{
				yield return fruitTimer;

				var block = blockFactory.GetFruit();
				block.transform.position = GetSpawnPosition(region);

				float randomAngle = Random.Range(region.MinAngle, region.MaxAngle);
				Vector2 pushDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.up;

				Vector2 speed =
					new Vector2(
						Random.Range(region.MinHorizontalSpeed, region.MaxHorizontalSpeed),
						Random.Range(region.MinVerticalSpeed, region.MaxVerticalSpeed)
						);

				block.Movement.Push(pushDirection * speed);
			}
		}

		private Region GetRegion()
		{
			int totalWeight = 0;
			foreach (var region in regions)
			{
				totalWeight += region.Priority;
			}

			int value = Random.Range(1, totalWeight + 1);
			int current = 0;

			foreach (var region in regions)
			{
				current += region.Priority;
				if (current >= value)
				{
					return region;
				}
			}

			return regions.Last();
		}

		private Vector2 GetSpawnPosition(Region region)
		{
			var start = Region.ToWorldPosition(mainCamera, region, region.Start);
			var end = Region.ToWorldPosition(mainCamera, region, region.End);
			return Vector2.Lerp(start, end, Random.value);
		}

		public IEnumerator SpawnCoroutine()
		{
			while (true)
			{
				yield return new WaitForSeconds(progressor.PackCooldown);
				yield return SpawnPack();
			}
		}

		void IResettable.ResetComponent()
		{
			progressor.ResetComponent();
		}
	}
}
