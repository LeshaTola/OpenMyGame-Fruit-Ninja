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
		[SerializeField] private ParticleSystem particleTemplate;

		[Header("Containers")]
		[SerializeField] private Transform blockContainer;
		[SerializeField] private Transform halvesContainer;
		[SerializeField] private Transform effectsContainer;
		[SerializeField] private Transform particlesContainer;
		[SerializeField] private Transform sliceUIContainer;


		public ObjectPool<Block> Fruits { get; private set; }
		public ObjectPool<Block> Bonuses { get; private set; }
		public ObjectPool<Block> Halves { get; private set; }

		public ObjectPool<Effect> Effects { get; private set; }
		public ObjectPool<SliceScoreUI> SliceUI { get; private set; }
		public ObjectPool<ParticleSystem> Particles { get; private set; }

		public void Init()
		{
			SetupFruitsPool();
			SetupHalvesPool();
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

		private void SetupHalvesPool()
		{
			int preloadCount = 10;
			Halves = new(
				() =>
				{
					var newBlock = Instantiate(blockTemplate, halvesContainer);
					newBlock.Init(null, 0f, () => Halves.Release(newBlock), null);
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

		private void SetupFruitsPool()
		{
			int preloadCount = 10;
			Fruits = new(
				() =>
				{
					var newBlock = Instantiate(blockTemplate, blockContainer);
					newBlock.Init(null, 0f, () => Fruits.Release(newBlock), null);
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
					var particleMain = particle.main;
					//particleMain.stopAction() => Particles.Release(particle);
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
