using UnityEngine;

namespace Spawn
{
	[CreateAssetMenu(fileName = "SpawnConfig", menuName = "Configs/Spawn/Spawn")]
	public class SpawnConfig : ScriptableObject
	{
		[Header("General")]
		[SerializeField] private float timeBetweenProgressions;

		[Header("Fruit Count")]
		[SerializeField] private float startFruitCount;
		[SerializeField, Min(0)] private int minFruitCount;
		[SerializeField] private int maxFruitCount;
		[SerializeField] private float fruitCountProgression;

		[Header("Fruit Cooldown")]
		[SerializeField] private float startFruitCooldown;
		[SerializeField, Min(0)] private float minFruitCooldown;
		[SerializeField] private float maxFruitCooldown;
		[SerializeField] private float fruitCooldownProgression;

		[Header("Pack Cooldown")]
		[SerializeField] private float startPackCooldown;
		[SerializeField, Min(0)] private float minPackCooldown;
		[SerializeField] private float maxPackCooldown;
		[SerializeField] private float packCooldownProgression;

		public float StartFruitCount { get => startFruitCount; }
		public int MinFruitCount { get => minFruitCount; }
		public float MaxFruitCount { get => maxFruitCount; }
		public float FruitCountProgression { get => fruitCountProgression; }

		public float StartFruitCooldown { get => startFruitCooldown; }
		public float MinFruitCooldown { get => minFruitCooldown; }
		public float MaxFruitCooldown { get => maxFruitCooldown; }
		public float FruitCooldownProgression { get => fruitCooldownProgression; }

		public float StartPackCooldown { get => startPackCooldown; }
		public float MinPackCooldown { get => minPackCooldown; }
		public float PackCooldownProgression { get => packCooldownProgression; }
		public float MaxPackCooldown { get => maxPackCooldown; }
		public float TimeBetweenProgressions { get => timeBetweenProgressions; }
	}
}