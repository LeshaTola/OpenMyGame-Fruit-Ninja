using General;
using System;
using UnityEngine;

namespace Spawn
{
	[CreateAssetMenu(fileName = "SpawnConfig", menuName = "Configs/Spawn/Spawn")]
	public class SpawnConfig : ScriptableObject
	{
		[Header("General")]
		[SerializeField] private float timeBetweenProgressions;

		[Header("Fruit Count")]
		[SerializeField] private ProgressionStruct fruits;

		[Header("Fruit Cooldown")]
		[SerializeField] private ProgressionStruct fruitCooldown;

		[Header("Pack Cooldown")]
		[SerializeField] private ProgressionStruct packCooldown;

		[SerializeField] private BlockSpawnConfig blockSpawnConfig;

		public float TimeBetweenProgressions { get => timeBetweenProgressions; }
		public ProgressionStruct FruitsCount { get => fruits; }
		public ProgressionStruct FruitCooldown { get => fruitCooldown; }
		public ProgressionStruct PackCooldown { get => packCooldown; }
		public BlockSpawnConfig BlockSpawnConfig { get => blockSpawnConfig; }

		public SpawnConfig Copy(
			SpawnConfig spawnConfig,
			BlockSpawnConfig blockSpawnConfig,
			float countMultiplier = 1,
			float blockCooldownMultiplier = 1,
			float packCooldownMultiplier = 1)
		{
			var newProgressor = CreateInstance<SpawnConfig>();
			newProgressor.fruits.StartValue = spawnConfig.fruits.StartValue * countMultiplier;
			newProgressor.fruitCooldown.StartValue = spawnConfig.fruitCooldown.StartValue * blockCooldownMultiplier;
			newProgressor.packCooldown.StartValue = spawnConfig.packCooldown.StartValue * packCooldownMultiplier;
			newProgressor.blockSpawnConfig = blockSpawnConfig;
			return newProgressor;
		}

	}

	[Serializable]
	public struct ProgressionStruct
	{
		public float StartValue;
		public MinMaxValue<float> Range;
		public float Progression;
	}
}