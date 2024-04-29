using Sirenix.Serialization;
using UnityEngine;

namespace Blocks.Configs.Bonuses
{
	public class MimicSwapConfig
	{
		[OdinSerialize] private Config blockConfig;
		[OdinSerialize][Range(0, 10)] private int weight;

		public Config BlockConfig { get => blockConfig; }
		public int Weight { get => weight; }
	}
}