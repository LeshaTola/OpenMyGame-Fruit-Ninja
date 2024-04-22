using Blocks.Configs;
using Blocks.Kill;
using Blocks.Logic;
using General;
using Health;
using Score;
using Slicing.Combo;
using Slicing.SliceStrategy;
using UnityEngine;

namespace Blocks.Factory
{
	public class BaseBlockFactory : IBlockFactory
	{
		private ObjectPoolsContainer poolsContainer;
		private ScoreController scoreController;
		private HealthController healthController;
		private ComboController comboController;

		public BaseBlockFactory
			(
				ObjectPoolsContainer poolsContainer,
				ScoreController scoreController,
				HealthController healthController,
				ComboController comboController
			)
		{
			this.poolsContainer = poolsContainer;
			this.scoreController = scoreController;
			this.healthController = healthController;
			this.comboController = comboController;

		}

		public Block GetBomb(BombConfig config)
		{
			var block = poolsContainer.Blocks.Get();

			var effectStrategy = new EffectSliceStrategyWrapper(new NoSliceStrategy(), block, poolsContainer.Effects);
			var reduceHealthStrategy = new ReduceHealthSliceStrategyWrapper(effectStrategy, block, healthController, config.ReduceHealth);
			var pushStrategy = new PushSliceStrategyWrapper(reduceHealthStrategy, block, poolsContainer.Blocks, config.ExplosionRadius, config.ExplosionForce);
			var textUIStrategy = new TextUISliceStrategyWrapper(pushStrategy, block, poolsContainer.SliceUI, config.Text);
			var releaseStrategy = new ReleaseSliceStrategyWrapper(textUIStrategy, block, poolsContainer.Blocks);

			var releaseKillStrategy = new ReleaseKillStrategyWrapper(new NoKillStrategy(), block, poolsContainer.Blocks);

			IBlock bombLogic = new BaseBlock(releaseStrategy, releaseKillStrategy);

			block.ResetBlock();
			block.Init(config, bombLogic);
			return block;
		}

		public Block GetFruit(FruitConfig config)
		{
			var block = poolsContainer.Blocks.Get();
			ISliceStrategy sliceStrategy = GetFruitSliceStrategy(block, config);

			var releaseKillStrategy = new ReleaseKillStrategyWrapper(new NoKillStrategy(), block, poolsContainer.Blocks);
			var reduceHealthStrategy = new ReduceHealthKillStrategyWrapper(releaseKillStrategy, block, healthController, config.FallReduceHealth);

			IBlock fruitLogic = new BaseBlock(sliceStrategy, reduceHealthStrategy);

			block.ResetBlock();
			block.Init(config, fruitLogic);
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

		private ISliceStrategy GetFruitSliceStrategy(Block block, FruitConfig config)
		{
			var halvesStrategy = new HalvesSliceStrategyWrapper(new NoSliceStrategy(), block, this, config.SliceForce);
			var effectStrategy = new EffectSliceStrategyWrapper(halvesStrategy, block, poolsContainer.Effects);
			var particleStrategy = new ParticleSliceStrategyWrapper(effectStrategy, block, poolsContainer.Particles, config.JuiceColor);
			var scoreStrategy = new ScoreSliceStrategyWrapper(particleStrategy, block, scoreController);
			var textUIStrategy = new TextUISliceStrategyWrapper(scoreStrategy, block, poolsContainer.SliceUI, config.Score.ToString());
			var comboStrategy = new ComboSliceStrategyWrapper(textUIStrategy, block, comboController);
			var releaseStrategy = new ReleaseSliceStrategyWrapper(comboStrategy, block, poolsContainer.Blocks);
			return releaseStrategy;
		}
	}
}
