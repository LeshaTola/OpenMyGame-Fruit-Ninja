using UnityEngine;

namespace Health
{
	[CreateAssetMenu(fileName = "HealthConfig", menuName = "Configs/Health/HealthConfig")]
	public class HealthConfig : ScriptableObject
	{
		[SerializeField] private int maxHealth;
		[SerializeField] private int defaultHealth;

		public int MaxHealth { get => maxHealth; }
		public int DefaultHealth { get => defaultHealth; }
	}
}
