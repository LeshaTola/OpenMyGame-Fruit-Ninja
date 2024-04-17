using Blocks;
using Score;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace General
{
	public class ObjectPoolsContainer : MonoBehaviour
	{
		[SerializeField] private ScoreController scoreController;
		[SerializeField] private Block blockTemplate;
		[SerializeField] private List<Config> blockConfigs;

		[SerializeField] private Effect effectTemplate;
		[SerializeField] private SliceScoreUI sliceUITemplate;
		[SerializeField] private ParticleSystem particleTemplate;

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
					var sliceUI = Instantiate(sliceUITemplate);
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
					var newBlock = Instantiate(blockTemplate);
					newBlock.Init(null, 0f, () => Halves.Release(newBlock));
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
					var newBlock = Instantiate(blockTemplate);
					newBlock.Init(blockConfigs[Random.Range(0, blockConfigs.Count)], () => Fruits.Release(newBlock), this, scoreController);
					return newBlock;
				},
				(block) =>
				{
					block.ResetBlock(blockConfigs[Random.Range(0, blockConfigs.Count)]);
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
					return Instantiate(effectTemplate);
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
					var particle = Instantiate(particleTemplate);
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
