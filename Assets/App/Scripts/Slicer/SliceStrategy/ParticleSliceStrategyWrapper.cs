using Blocks;
using UnityEngine;
using Utility;

namespace Slicing.SliceStrategy
{
	public class ParticleSliceStrategyWrapper : BaseSliceStrategyWrapper
	{
		private ObjectPool<ParticleSystem> particlesPool;

		public ParticleSliceStrategyWrapper(ISliceStrategy sliceStrategy, Block block, ObjectPool<ParticleSystem> particlesPool) : base(sliceStrategy, block)
		{
			this.particlesPool = particlesPool;
		}

		public override void Slice(Vector2 delta)
		{
			base.Slice(delta);

			ParticleSystem particles = particlesPool.Get();
			particles.transform.position = block.transform.position;
			particles.transform.rotation = Quaternion.identity;

			ParticleSystem.MainModule particlesMain = particles.main;
			particlesMain.startColor = block.Config.JuiceColor;

			particles.Play();
		}
	}
}
