using System;
using UnityEngine;

namespace Score
{
	public class ScoreController : MonoBehaviour
	{
		public event Action<int> OnScoreChanged;

		private int currentScore;

		public void AddScore(int score)
		{
			if (score <= 0)
			{
				return;
			}
			currentScore += score;
			OnScoreChanged?.Invoke(currentScore);
		}

	}
}