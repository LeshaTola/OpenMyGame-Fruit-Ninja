using UnityEngine;

namespace Blocks.Configs.Component
{
	[CreateAssetMenu(fileName = "PushComponent", menuName = "Configs/Blocks/Components/PushComponent")]
	public class PushComponent : BasicComponent
	{
		[SerializeField] private float influenceRadius;
		[SerializeField] private float force;

		public override void Execute(Block block)
		{
			foreach (var otherBlock in Context.PoolsContainer.Blocks.Active)
			{
				Vector2 pushDirection = otherBlock.transform.position - block.transform.position;
				if (pushDirection.magnitude < influenceRadius)
				{
					float forceModifier = (influenceRadius - pushDirection.magnitude) / influenceRadius;
					otherBlock.Movement.Push(pushDirection.normalized * force * forceModifier);
				}
			}
		}
	}
}

