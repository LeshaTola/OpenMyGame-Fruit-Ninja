using UnityEngine;

namespace Blocks.Configs
{
	public class FruitConfig : Config
	{
		[Header("Fruit")]
		[SerializeField] private ParticleSystem juiceParticle;
		[SerializeField] private Color juiceColor;

		public ParticleSystem JuiceParticle { get => juiceParticle; }
		public Color JuiceColor { get => juiceColor; }
	}
}
