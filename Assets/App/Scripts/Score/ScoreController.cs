using General;
using SaveLoad;
using System;
using UnityEngine;

namespace Score
{
	public class ScoreController : MonoBehaviour, IResettable
	{
		public event Action<int> OnScoreChanged;
		public event Action<int> OnBestScoreChanged;

		private int currentScore = 0;
		private int bestScore = 0;

		public int BestScore { get => bestScore; }

		public void AddScore(int score)
		{
			if (score <= 0)
			{
				return;
			}
			currentScore += score;
			OnScoreChanged?.Invoke(currentScore);

			if (currentScore > bestScore)
			{
				UpdateBestScore(currentScore);
			}
		}

		private void UpdateBestScore(int score)
		{
			bestScore = score;
			OnBestScoreChanged?.Invoke(bestScore);
		}

		public void ResetComponent()
		{
			currentScore = 0;
			OnScoreChanged?.Invoke(currentScore);

			var loadedBestScore = SaveLoadSystem.Load();
			bestScore = loadedBestScore.BestScore;
			UpdateBestScore(bestScore);
		}
	}
}