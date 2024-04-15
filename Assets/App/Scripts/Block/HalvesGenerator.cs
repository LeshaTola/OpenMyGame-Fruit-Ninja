using System.Collections.Generic;
using UnityEngine;

namespace Blocks
{
	public class HalvesGenerator : MonoBehaviour
	{
		[SerializeField] private List<Config> blockConfigs;

		private void Awake()
		{
			foreach (var config in blockConfigs)
			{
				config.GenerateHalves();
			}
		}
	}
}
