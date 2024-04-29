using UnityEngine;

namespace Blocks.Configs.Component
{
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
