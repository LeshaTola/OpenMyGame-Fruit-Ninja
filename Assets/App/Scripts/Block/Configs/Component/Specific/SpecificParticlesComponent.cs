using UnityEngine;

namespace Blocks.Configs.Component
{
	public class SpecificParticlesComponent : BasicComponent
	{
		[SerializeField] private ParticleSystem particles;

		public override void Execute(Block block)
		{
			var newParticles = GameObject.Instantiate(particles);
			newParticles.transform.position = block.transform.position;
			newParticles.transform.rotation = Quaternion.identity;

			newParticles.Play();
		}
	}
}
