using Blocks;
using Blocks.Configs;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
	[CreateAssetMenu(fileName = "BlocksSpawnConfig", menuName = "Configs/Spawn/BlocksSpawnConfig")]
	public class BlockSpawnConfig : ScriptableObject
	{
		[Header("Fruits")]
		[SerializeField] private List<FruitConfig> fruits;

		[Header("Bomb")]
		[SerializeField] private ConfigProperties bomb;

		public ConfigProperties Bomb { get => bomb; }
		public List<FruitConfig> Fruits { get => fruits; }
	}

	[Serializable]
	public struct ConfigProperties
	{
		public Config Config;
		[Tooltip("Percentage of the main pack")]
		[Range(0, 1)] public float MaxCount;
		[Range(0, 1)] public float Chance;
	}
}
