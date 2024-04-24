using Blocks;
using Spawn.BlockSpawnLogic;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
	[CreateAssetMenu(fileName = "BlocksSpawnConfig", menuName = "Configs/Spawn/BlocksSpawnConfig")]
	public class BlockSpawnConfig : ScriptableObject
	{
		[Header("Fruits")]
		[SerializeField] private List<Config> fruits = new();

		[Header("Bonuses")]
		[SerializeField] private List<ConfigProperties> bonuses = new();

		public IReadOnlyCollection<ConfigProperties> Bonuses { get => bonuses; }
		public List<Config> Fruits { get => fruits; }
	}

	[Serializable]
	public struct ConfigProperties
	{
		public Config Config;
		public BasicSpawnLogic SpawnLogic;
	}
}
