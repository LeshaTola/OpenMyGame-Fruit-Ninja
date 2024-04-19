using Blocks.Kill;
using Blocks.Logic;
using General;
using Health;
using Score;
using Slicing.Combo;
using Slicing.SliceStrategy;
using System.Collections.Generic;
using UnityEngine;

namespace Blocks.Factory
{
	public class BaseBlockFactory : IBlockFactory
	{
		private ObjectPoolsContainer poolsContainer;
		private ScoreController scoreController;
		private HealthController healthController;
		private ComboController comboController;
		private List<Config> blockConfigs;

		public BaseBlockFactory
			(
			ObjectPoolsContainer poolsContainer,
			ScoreController scoreController,
			HealthController healthController,
			ComboController comboController,
			List<Config> blockConfigs
			)
		{
			this.poolsContainer = poolsContainer;
			this.scoreController = scoreController;
			this.healthController = healthController;
			this.comboController = comboController;
			this.blockConfigs = blockConfigs;
		}

		public Block GetBomb()
		{
			throw new System.NotImplementedException();
		}

		public Block GetFruit()
		{
			var block = poolsContainer.Blocks.Get();
			ISliceStrategy sliceStrategy = GetFruitSliceStrategy(block);


			var releaseKillStrategy = new ReleaseKillStrategyWrapper(new NoKillStrategy(), block, poolsContainer.Blocks);
			var reduceHealthStrategy = new ReduceHealthKillStrategyWrapper(releaseKillStrategy, block, healthController, 1);

			IBlock fruitLogic = new BaseBlock(sliceStrategy, reduceHealthStrategy);

			block.ResetBlock();
			block.Init(blockConfigs[Random.Range(0, blockConfigs.Count)], fruitLogic);
			return block;
		}

		public Block GetHalf(Sprite sprite, float radius)
		{
			var half = poolsContainer.Blocks.Get();
			half.ResetBlock();

			var releaseKillStrategy = new ReleaseKillStrategyWrapper(new NoKillStrategy(), half, poolsContainer.Blocks);
			IBlock halfLogic = new BaseBlock(new NoSliceStrategy(), releaseKillStrategy);

			half.Init(sprite, radius, halfLogic);
			return half;
		}

		private ISliceStrategy GetFruitSliceStrategy(Block block)
		{
			var halvesStrategy = new HalvesSliceStrategyWrapper(new NoSliceStrategy(), block, this, 5);
			var effectStrategy = new EffectSliceStrategyWrapper(halvesStrategy, block, poolsContainer.Effects);
			var particleStrategy = new ParticleSliceStrategyWrapper(effectStrategy, block, poolsContainer.Particles);
			var scoreUIStrategy = new ScoreSliceStrategyWrapper(particleStrategy, block, poolsContainer.SliceUI, scoreController, 2);
			var comboStrategy = new ComboSliceStrategyWrapper(scoreUIStrategy, block, comboController);
			var destroyStrategy = new ReleaseSliceStrategyWrapper(comboStrategy, block, poolsContainer.Blocks);
			return destroyStrategy;
		}
	}
}
