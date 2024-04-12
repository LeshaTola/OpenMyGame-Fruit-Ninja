using System.Collections.Generic;
using UnityEngine;

namespace Block
{
	[CreateAssetMenu(fileName = "BlockConfig", menuName = "Configs/Block/Block")]
	public class BlockConfig : ScriptableObject
	{
		[SerializeField] private Sprite blockSprite;
		[SerializeField] private Sprite sliceEffect;

		public Sprite BlockSprite { get => blockSprite; }
		public Sprite SliceEffect { get => sliceEffect; }

		public List<Sprite> HalfSprites { get; private set; }

		private void OnValidate()
		{
			int halfCount = 2;
			HalfSprites = new List<Sprite>(2);

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
