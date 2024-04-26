using General;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Score
{
	public class ScoreUI : MonoBehaviour, IInitable
	{
		[SerializeField] private ScoreController scoreController;
		[SerializeField] private TextMeshProUGUI currentScoreText;
		[SerializeField] private TextMeshProUGUI bestScoreText;
		[SerializeField] private float animationTime = 3f;

		private Coroutine currentScoreCoroutine;
		private Coroutine bestScoreCoroutine;

		public void Init()
		{
			scoreController.OnScoreChanged += OnScoreChanged;
			scoreController.OnBestScoreChanged += OnBestScoreChanged;
		}

		private void OnDestroy()
		{
			scoreController.OnScoreChanged -= OnScoreChanged;
			scoreController.OnBestScoreChanged -= OnBestScoreChanged;
		}

		private void OnScoreChanged(int score)
		{
			var currentScore = int.Parse(currentScoreText.text);
			if (currentScoreCoroutine != null)
			{
				StopCoroutine(currentScoreCoroutine);
			}
			currentScoreCoroutine = StartCoroutine(AnimationCoroutine(currentScoreText, score, currentScore));
		}

		private void OnBestScoreChanged(int score)
		{
			var currentScore = int.Parse(bestScoreText.text);
			if (bestScoreCoroutine != null)
			{
				StopCoroutine(bestScoreCoroutine);
			}
			bestScoreCoroutine = StartCoroutine(AnimationCoroutine(bestScoreText, score, currentScore));
		}

		private IEnumerator AnimationCoroutine(TextMeshProUGUI text, int target, float current)
		{
			float scoreSpeed = (target - current) / animationTime;
			while (current < target)
			{
				current += scoreSpeed * Time.deltaTime;
				text.text = ((int)current).ToString();
				yield return null;
			}
			text.text = target.ToString();
		}
	}
}