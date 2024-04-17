using System.Collections;
using TMPro;
using UnityEngine;

namespace Score
{
	public class ScoreUI : MonoBehaviour
	{
		[SerializeField] private ScoreController scoreController;
		[SerializeField] private TextMeshProUGUI currentScoreText;
		[SerializeField] private float animationTime = 3f;

		private int targetScore;
		private float currentScore;

		public void Init()
		{
			scoreController.OnScoreChanged += OnScoreChanged;
		}

		private void OnDestroy()
		{
			scoreController.OnScoreChanged -= OnScoreChanged;
		}

		private void OnScoreChanged(int score)
		{
			StopAllCoroutines();
			targetScore = score;
			StartCoroutine(AnimationCoroutine());
		}

		private IEnumerator AnimationCoroutine()
		{
			float scoreSpeed = (targetScore - currentScore) / animationTime;
			while (currentScore < targetScore)
			{
				currentScore += scoreSpeed * Time.deltaTime;
				currentScoreText.text = ((int)currentScore).ToString();
				yield return null;
			}
			currentScoreText.text = targetScore.ToString();
		}

	}
}