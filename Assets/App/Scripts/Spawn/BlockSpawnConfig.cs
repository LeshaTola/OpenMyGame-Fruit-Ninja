using Blocks;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Spawn.BlockSpawnLogic;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{

	[CreateAssetMenu(fileName = "BlocksSpawnConfig", menuName = "Configs/Spawn/BlocksSpawnConfig")]
	public class BlockSpawnConfig : SerializedScriptableObject
	{
		[Header("Fruits")]
		[SerializeField] private List<Config> fruits = new();
		[Range(1, 100)][SerializeField] private int fruitsWeight;

		[SerializeField] private List<ConfigProperties> bonuses = new();

		public int FruitsWeight { get => fruitsWeight; }

		public IReadOnlyCollection<ConfigProperties> Bonuses { get => bonuses; }
		public List<Config> Fruits { get => fruits; }

	}

	[Serializable]
	public class ConfigProperties
	{
		[FoldoutGroup("@BonusName")]
		[OdinSerialize]
		public string BonusName;

		[FoldoutGroup("@BonusName")]
		[OdinSerialize] public Config Config;

		[FoldoutGroup("@BonusName")]
		[OdinSerialize]
		[ShowInInspector]
		[InlineProperty]
		[SerializeReference]
		public IBlockSpawnLogic SpawnLogic;

		[FoldoutGroup("@BonusName")]
		[OdinSerialize]
		[Range(0, 100)] public int Weight;
	}
}
