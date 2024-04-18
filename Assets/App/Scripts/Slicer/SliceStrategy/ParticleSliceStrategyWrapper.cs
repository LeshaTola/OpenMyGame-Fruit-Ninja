using Blocks;
using UnityEngine;
using Utility;

namespace Slicing.SliceStrategy
{
	public class ParticleSliceStrategyWrapper : BaseSliceStrategyWrapper
	{
		private ObjectPool<JuiceParticles> particlesPool;

		public ParticleSliceStrategyWrapper(ISliceStrategy sliceStrategy, Block block, ObjectPool<JuiceParticles> particlesPool) : base(sliceStrategy, block)
		{
			this.particlesPool = particlesPool;
		}

		public override void Slice(Vector2 delta)
		{
			base.Slice(delta);

			var particles = particlesPool.Get();
			particles.transform.position = block.transform.position;
			particles.transform.rotation = Quaternion.identity;

			particles.SwapColor(block.Config.JuiceColor);
			particles.Play();
		}
	}
}
