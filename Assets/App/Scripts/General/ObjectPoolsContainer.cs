using Blocks;
using UnityEngine;
using Utility;

namespace General
{
	public class ObjectPoolsContainer : MonoBehaviour
	{
		[Header("Templates")]
		[SerializeField] private Block blockTemplate;
		[SerializeField] private Effect effectTemplate;
		[SerializeField] private SliceScoreUI sliceUITemplate;
		[SerializeField] private JuiceParticles particleTemplate;

		[Header("Containers")]
		[SerializeField] private Transform blockContainer;
		[SerializeField] private Transform effectsContainer;
		[SerializeField] private Transform particlesContainer;
		[SerializeField] private Transform sliceUIContainer;

		public ObjectPool<Block> Blocks { get; private set; }
		public ObjectPool<Block> Bonuses { get; private set; }

		public ObjectPool<Effect> Effects { get; private set; }
		public ObjectPool<SliceScoreUI> SliceUI { get; private set; }
		public ObjectPool<JuiceParticles> Particles { get; private set; }

		public void Init()
		{
			SetupBlocksPool();
			SetupEffectsPool();
			SetupParticlesPool();
			SetupSliceTextPool();
		}

		private void SetupSliceTextPool()
		{
			int preloadCount = 10;
			SliceUI = new(
				() =>
				{
					var sliceUI = Instantiate(sliceUITemplate, sliceUIContainer);
					return sliceUI;
				},
				(UI) =>
				{
					UI.Movement.Reset();
					UI.gameObject.SetActive(true);
				},
				(UI) =>
				{
					UI.gameObject.SetActive(false);
				},
				preloadCount
				);
		}

		private void SetupBlocksPool()
		{
			int preloadCount = 10;
			Blocks = new(
				() =>
				{
					var newBlock = Instantiate(blockTemplate, blockContainer);
					newBlock.Init(null, 0f, null);
					return newBlock;
				},
				(block) =>
				{
					block.gameObject.SetActive(true);
				},
				(block) =>
				{
					block.gameObject.SetActive(false);
				},
				preloadCount
				);
		}

		private void SetupEffectsPool()
		{
			int preloadCount = 10;
			Effects = new(
				() =>
				{
					return Instantiate(effectTemplate, effectsContainer);
				},
				(block) =>
				{
					block.gameObject.SetActive(true);
				},
				(block) =>
				{
					block.gameObject.SetActive(false);
				},
				preloadCount
				);
		}

		private void SetupParticlesPool()
		{
			int preloadCount = 10;
			Particles = new(
				() =>
				{
					var particle = Instantiate(particleTemplate, particlesContainer);
					particle.Init(() => Particles.Release(particle));
					return particle;
				},
				(block) =>
				{
					block.gameObject.SetActive(true);
				},
				(block) =>
				{
					block.gameObject.SetActive(false);
				},
				preloadCount
				);
		}
	}
}
