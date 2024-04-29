using Blocks.Configs.Bonuses;
using Blocks.Configs.Bonuses.Mimic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

namespace Blocks.Configs.SpawnComponent
{
	public class MimicComponent : BasicSpawnComponent
	{
		[SerializeField] private float swapCooldown;
		[SerializeField] private float timeBeforeParticles;
		[SerializeField] private MimicController mimicController;

		[OdinSerialize]
		[InlineProperty]
		private List<MimicSwapConfig> swapConfigs;

		public override void Start()
		{
			MimicController newMimicController = GameObject.Instantiate(mimicController, Block.transform);
			newMimicController.Init(swapCooldown, timeBeforeParticles, swapConfigs, Block, Context);
			Context.BonusController.AddBonus(newMimicController);
		}
	}
}
