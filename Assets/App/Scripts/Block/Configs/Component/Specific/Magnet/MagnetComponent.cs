using System.Collections.Generic;
using UnityEngine;

namespace Blocks.Configs.Component
{
	[CreateAssetMenu(fileName = "MagnetComponent", menuName = "Configs/Blocks/Components/Specific/Magnet/MagnetComponent")]
	public class MagnetComponent : BasicComponent
	{
		[Header("Prefab")]
		[SerializeField] private MagnetArea area;

		[Header("Settings")]
		[SerializeField] private float strength;
		[SerializeField] private float radius;
		[SerializeField] private float lifeTime;
		[SerializeField] private List<Config> whiteList;

		public override void Execute(Block block)
		{
			MagnetArea newMagnetArea = Instantiate(area, block.transform.position, Quaternion.identity);
			newMagnetArea.Init(strength, radius, lifeTime, Context, whiteList);
			newMagnetArea.StartPull();
		}

	}
}
