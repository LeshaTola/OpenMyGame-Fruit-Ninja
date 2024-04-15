using System.Collections.Generic;
using UnityEngine;

namespace Blocks
{
	[CreateAssetMenu(fileName = "BlockConfig", menuName = "Configs/Block/Block")]
	public class Config : ScriptableObject
	{
		[SerializeField] private Sprite blockSprite;
		[SerializeField] private Sprite sliceEffect;
		[SerializeField] private ParticleSystem juiceParticle;
		[SerializeField] private Color juiceColor;
		[SerializeField] private float radius;

		private List<Sprite> halfSprites;

		public Sprite BlockSprite { get => blockSprite; }
		public Sprite SliceEffect { get => sliceEffect; }
		public ParticleSystem JuiceParticle { get => juiceParticle; }
		public Color JuiceColor { get => juiceColor; }
		public float Radius { get => radius; }

		public List<Sprite> HalfSprites { get => halfSprites; }

		public void GenerateHalves()
		{
			int halfCount = 2;
			halfSprites = new List<Sprite>(halfCount);

			for (int i = 0; i < halfCount; i++)
			{
				float halfHeight = blockSprite.rect.size.y / halfCount;
				Vector2 position = new(blockSprite.rect.position.x, halfHeight * i);
				Rect halfRect = new(position, new Vector2(blockSprite.rect.size.x, halfHeight));
				var halfSprite = Sprite.Create(blockSprite.texture, halfRect, new Vector2(0.5f, 0.5f));
				HalfSprites.Add(halfSprite);
			}
		}
	}
}
