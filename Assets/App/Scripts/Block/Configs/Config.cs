using System.Collections.Generic;
using UnityEngine;

namespace Blocks
{
	[CreateAssetMenu(fileName = "BlockConfig", menuName = "Configs/Block/Block")]
	public abstract class Config : ScriptableObject
	{
		[Header("General")]
		[SerializeField] private Sprite blockSprite;
		[SerializeField] private Sprite sliceEffect;
		[SerializeField] private float radius;
		[SerializeField] private int score;
		[SerializeField] private int fallReduceHealth;
		[SerializeField] private float sliceForce;

		private List<Sprite> halfSprites;

		public Sprite BlockSprite { get => blockSprite; }
		public Sprite SliceEffect { get => sliceEffect; }
		public float Radius { get => radius; }
		public int Score { get => score; }
		public int FallReduceHealth { get => fallReduceHealth; }

		public List<Sprite> HalfSprites { get => halfSprites; }
		public float SliceForce { get => sliceForce; }

		private void OnValidate()//TODO swap with global init state in stateMachine
		{
			GenerateHalves();
		}

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
