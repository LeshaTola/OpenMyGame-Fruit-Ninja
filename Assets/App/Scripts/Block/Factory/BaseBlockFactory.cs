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

		public BaseBlockFactory(ObjectPoolsContainer poolsContainer, ScoreController scoreController, HealthController healthController, ComboController comboController, List<Config> blockConfigs)
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
			var block = poolsContainer.Fruits.Get();

			var halvesStrategy = new HalvesSliceStrategyWrapper(new NoSliceStrategy(), block, poolsContainer.Halves, 2);
			var effectStrategy = new EffectSliceStrategyWrapper(halvesStrategy, block, poolsContainer.Effects);
			var particleStrategy = new ParticleSliceStrategyWrapper(effectStrategy, block, poolsContainer.Particles);
			var scoreUIStrategy = new ScoreSliceStrategyWrapper(particleStrategy, block, poolsContainer.SliceUI, scoreController, 2);
			var comboStrategy = new ComboSliceStrategyWrapper(scoreUIStrategy, block, comboController);
			var destroyStrategy = new DestroySliceStrategyWrapper(comboStrategy, block);
			block.ResetBlock();
			block.Init(blockConfigs[Random.Range(0, blockConfigs.Count)], () => { poolsContainer.Fruits.Release(block); }, new FruitBlock(destroyStrategy));
			return block;
		}

		public Block GetHalf()
		{
			throw new System.NotImplementedException();
		}
	}
}
