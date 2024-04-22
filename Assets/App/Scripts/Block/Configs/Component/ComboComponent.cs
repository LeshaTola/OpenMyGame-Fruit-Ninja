using UnityEngine;

namespace Blocks.Configs.Component
{
	[CreateAssetMenu(fileName = "ComboComponent", menuName = "Configs/Blocks/Components/ComboComponent")]
	public class ComboComponent : BasicComponent
	{
		[SerializeField] private ScoreComponent scoreComponent;

		public override void Execute(Block block)
		{
			Context.ComboController.AddCombo(block, scoreComponent.Score);
		}
	}
}
