using UnityEngine;

namespace Blocks.Configs.Component
{
	[CreateAssetMenu(fileName = "ScoreComponent", menuName = "Configs/Blocks/Components/ScoreComponent")]
	public class ScoreComponent : BasicComponent
	{
		[SerializeField] private int score;

		public int Score { get => score; }

		public override void Execute(Block block)
		{
			Context.ScoreController.AddScore(score);
		}
	}
}
