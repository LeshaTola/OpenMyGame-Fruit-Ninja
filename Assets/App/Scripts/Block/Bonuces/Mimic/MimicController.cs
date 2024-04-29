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
			SwapSubscriptions(block, newConfig);
			block.Visual.RestartAnimation();
			block.Init(newConfig, context);

			SetupParticles(newConfig);
		}

		private void SetupParticles(Config newConfig)
		{
			ShapeModule preSwapParticleShape = particles.shape;
			ShapeModule swapParticleShape = swapParticles.shape;

			preSwapParticleShape.radius = newConfig.Radius;
			swapParticleShape.radius = newConfig.Radius;
		}

		private void SwapSubscriptions(Block block, Config newConfig)
		{
			ReleaseComponent sliceReleaseComponent = block.Config.GetSlicingComponent<ReleaseComponent>();
			ReleaseComponent killReleaseComponent = block.Config.GetKillingComponent<ReleaseComponent>();

			if (sliceReleaseComponent != null)
				sliceReleaseComponent.OnRelease -= SetInvalid;
			if (killReleaseComponent != null)
				killReleaseComponent.OnRelease -= SetInvalid;

			sliceReleaseComponent = newConfig.GetSlicingComponent<ReleaseComponent>();
			killReleaseComponent = newConfig.GetKillingComponent<ReleaseComponent>();

			if (sliceReleaseComponent != null)
				sliceReleaseComponent.OnRelease += SetInvalid;
			if (killReleaseComponent != null)
				killReleaseComponent.OnRelease += SetInvalid;
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
