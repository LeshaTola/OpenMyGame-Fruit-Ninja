using UnityEngine;

namespace Blocks.Configs.Component
{
	[CreateAssetMenu(fileName = "HealthComponent", menuName = "Configs/Blocks/Components/HealthComponent")]
	public class HealthComponent : BasicComponent
	{
		[SerializeField] private int health;

		public override void Execute(Block block)
		{
			Context.HealthController.ReduceHealth(health);
		}
	}
}
