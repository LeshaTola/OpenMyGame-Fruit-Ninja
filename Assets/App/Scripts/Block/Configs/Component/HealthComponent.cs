using UnityEngine;

namespace Blocks.Configs.Component
{
	public class HealthComponent : BasicComponent
	{
		[SerializeField] private int health;

		public override void Execute(Block block)
		{
			Context.HealthController.ReduceHealth(health);
		}
	}
}
