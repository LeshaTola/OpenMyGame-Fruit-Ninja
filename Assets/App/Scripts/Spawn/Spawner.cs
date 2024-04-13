using Blocks;
using Regions;
using Spawn.Progressor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;

namespace Spawn
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private List<Region> regions;
		[SerializeField] private List<BlockConfig> blockConfigs;
		[SerializeField] private Block blockTemplate;
		[SerializeField] private SpawnConfig config;
		[SerializeField] private Camera mainCamera;

		private IProgressor progressor;

		public IReadOnlyCollection<Region> Regions { get => regions; }
		public ObjectPool<Block> BlocksPool { get; private set; }

		private void Awake()
		{
			SetupPool();
		}

		public void Init(IProgressor progressor)
		{
			this.progressor = progressor;
			progressor.Init(config, this);
			StartCoroutine(SpawnCoroutine());
		}

		public IEnumerator SpawnPack()
		{
			Region region = GetRegion();

			var fruitTimer = new WaitForSeconds(progressor.FruitCooldown);
			for (int i = 0; i < progressor.FruitCount; i++)
			{
				yield return fruitTimer;

				var block = BlocksPool.Get();
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

		private void SetupPool()
		{
			BlocksPool = new(
				() =>
				{
					var newBlock = Instantiate(blockTemplate);
					newBlock.Init(blockConfigs[Random.Range(0, blockConfigs.Count)]);
					newBlock.OnDestroy += () => BlocksPool.Release(newBlock);
					return newBlock;
				},
				(block) =>
				{
					block.Movement.Reset();
					block.BlockAnimation.Restart();
					block.gameObject.SetActive(true);
				},
				(block) =>
				{
					block.gameObject.SetActive(false);
				},
				10
				);
		}

		private IEnumerator SpawnCoroutine()
		{
			while (true)
			{
				yield return new WaitForSeconds(progressor.PackCooldown);
				yield return SpawnPack();
			}
		}
	}
}
