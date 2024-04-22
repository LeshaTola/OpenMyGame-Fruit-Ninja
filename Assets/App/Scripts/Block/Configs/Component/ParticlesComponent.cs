using UnityEngine;

namespace Blocks.Configs.Component
{
	[CreateAssetMenu(fileName = "ParticlesComponent", menuName = "Configs/Blocks/Components/ParticlesComponent")]
	public class ParticlesComponent : BasicComponent
	{
		[SerializeField] private Color color;
		public override void Execute(Block block)
		{
			var particles = Context.PoolsContainer.Particles.Get();
			particles.transform.position = block.transform.position;
			particles.transform.rotation = Quaternion.identity;

			particles.SwapColor(color);
			particles.Play();
		}
	}
}
