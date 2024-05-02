using Assets.App.Scripts.General;
using Blocks.Configs.Bonuses;
using Blocks.Configs.Component;
using Blocks.Configs.Component.Specific;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace Blocks.Bonuses.Mimic
{
	public class MimicController : MonoBehaviour, IBonusComponent
	{
		[SerializeField] private float swapCooldown;
		[SerializeField] private float timeBeforeParticles;
		[SerializeField] private ParticleSystem particles;
		[SerializeField] private ParticleSystem swapParticles;

		[OdinSerialize]
		[InlineProperty]
		private List<MimicSwapConfig> swapConfigs;

		private Block block;
		private Context context;
		private float timer;

		public bool IsValid { get; private set; }

		public void Init(
			float swapCooldown,
			float timeBeforeParticles,
			List<MimicSwapConfig> swapConfigs,
			Block block,
			Context context)
		{
			this.swapCooldown = swapCooldown;
			this.timeBeforeParticles = timeBeforeParticles;
			this.swapConfigs = swapConfigs;
			this.block = block;
			this.context = context;
		}

		public void StartBonus()
		{
			Swap(block);
			IsValid = true;
			timer = swapCooldown;
		}

		public void UpdateBonus()
		{
			timer -= Time.deltaTime;
			if (timer <= timeBeforeParticles && !particles.isPlaying)
			{
				particles.Play();
			}

			if (timer <= 0)
			{
				timer = swapCooldown;
				Swap(block);
				swapParticles.Play();
				particles.Stop();
			}
		}

		public void StopBonus()
		{
			Destroy(gameObject);
		}

		private void Swap(Block block)
		{
			Config newConfig = GetConfig();

			SwapReleaseComponents(block, newConfig);
			SwapVisual(block, newConfig);

			SetupParticles(newConfig);
		}

		private void SwapReleaseComponents(Block block, Config newConfig)
		{
			block.Config.GetSlicingComponent<ReleaseComponent>()?.ClearAdditionalAction();
			block.Config.GetKillingComponent<ReleaseComponent>()?.ClearAdditionalAction();

			newConfig.GetSlicingComponent<ReleaseComponent>()?.SetAdditionalAction(SetInvalid);
			newConfig.GetKillingComponent<ReleaseComponent>()?.SetAdditionalAction(SetInvalid);
		}

		private void SwapVisual(Block block, Config newConfig)
		{
			var prevRotation = block.Visual.transform.rotation;
			var prevScale = block.Visual.transform.localScale;

			block.Visual.RestartAnimation();
			block.Init(newConfig, context);

			block.Visual.transform.rotation = prevRotation;
			block.Visual.transform.localScale = prevScale;
		}

		private void SetupParticles(Config newConfig)
		{
			ShapeModule preSwapParticleShape = particles.shape;
			ShapeModule swapParticleShape = swapParticles.shape;

			preSwapParticleShape.radius = newConfig.Radius;
			swapParticleShape.radius = newConfig.Radius;
		}

		private void SetInvalid()
		{
			IsValid = false;
		}

		private Config GetConfig()
		{
			int totalWeight = 0;
			foreach (var config in swapConfigs)
			{
				totalWeight += config.Weight;
			}

			int value = Random.Range(1, totalWeight + 1);
			int current = 0;

			foreach (var config in swapConfigs)
			{
				current += config.Weight;
				if (current >= value)
				{
					return config.BlockConfig;
				}
			}

			return swapConfigs.Last().BlockConfig;
		}
	}
}
