using Blocks.Configs.Component;
using System.Collections.Generic;
using UnityEngine;

namespace Blocks
{
	[CreateAssetMenu(fileName = "BlockConfig", menuName = "Configs/Blocks/Block")]
	public class Config : ScriptableObject
	{
		[Header("General")]
		[SerializeField] private Sprite blockSprite;
		[SerializeField] private float radius;

		[SerializeField] private List<BasicComponent> sliceComponents = new();
		[SerializeField] private List<BasicComponent> killComponents = new();

		private List<Sprite> halfSprites;

		public Sprite BlockSprite { get => blockSprite; }
		public float Radius { get => radius; }

		public List<BasicComponent> SliceComponents { get => sliceComponents; }
		public List<BasicComponent> KillComponents { get => killComponents; }

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
