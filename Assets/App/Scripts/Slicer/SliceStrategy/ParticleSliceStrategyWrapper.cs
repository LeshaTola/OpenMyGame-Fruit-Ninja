using Blocks;
using UnityEngine;
using Utility;

namespace Slicing.SliceStrategy
{
	public class ParticleSliceStrategyWrapper : BaseSliceStrategyWrapper
	{
		private ObjectPool<JuiceParticles> particlesPool;
		private Color particlesColor;

		public ParticleSliceStrategyWrapper(ISliceStrategy sliceStrategy, Block block, ObjectPool<JuiceParticles> particlesPool, Color particlesColor) : base(sliceStrategy, block)
		{
			this.particlesPool = particlesPool;
			this.particlesColor = particlesColor;
		}

		public override void Slice(Vector2 delta)
		{
			base.Slice(delta);

			var particles = particlesPool.Get();
			particles.transform.position = block.transform.position;
			particles.transform.rotation = Quaternion.identity;

			particles.SwapColor(particlesColor);
			particles.Play();
		}
	}
}
