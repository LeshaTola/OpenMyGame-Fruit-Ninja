using UnityEngine;

namespace Blocks.Configs
{
	public class BombConfig : Config
	{
		[Header("Bomb")]
		[SerializeField] private float explosionRadius;
		[SerializeField] private float explosionForce;
		[SerializeField] private int reduceHealth;
		[SerializeField] private string text;

		public float ExplosionRadius { get => explosionRadius; }
		public float ExplosionForce { get => explosionForce; }
		public int ReduceHealth { get => reduceHealth; }
		public string Text { get => text; }
	}
}
