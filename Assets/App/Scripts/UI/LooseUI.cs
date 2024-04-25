using Scenes.GamePlay.StateMachine;
using Score;
using StateMachine.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{

	public class LooseUI : MonoBehaviour
	{
		[SerializeField] private ScoreController scoreController;
		[SerializeField] private GamePlayStateMachine stateMachine;
		[SerializeField] private PanelAnimation panelAnimation;

		[SerializeField] private Button restartButton;
		[SerializeField] private Button menuButton;

		[SerializeField] private TextMeshProUGUI scoreText;
		[SerializeField] private string bestScorePreText;
		[SerializeField] private TextMeshProUGUI bestScoreText;

		public void Init()
		{
			restartButton.onClick.AddListener(() => stateMachine.Core.SetState<ResetState>());
			menuButton.onClick.AddListener(() => stateMachine.Core.SetState<LoadSceneState>());

			scoreController.OnScoreChanged += OnScoreChanged;
			scoreController.OnBestScoreChanged += OnBestScoreChanged;

			Hide();
		}

		private void OnDestroy()
		{
			scoreController.OnScoreChanged -= OnScoreChanged;
			scoreController.OnBestScoreChanged -= OnBestScoreChanged;
		}

		public void Show()
		{
			panelAnimation.PlayShowAnimation();
		}

		public void Hide()
		{
			panelAnimation.PlayHideAnimation();
		}

		private void OnBestScoreChanged(int score)
		{
			bestScoreText.text = bestScorePreText + score.ToString();
		}

		private void OnScoreChanged(int score)
		{
			scoreText.text = score.ToString();
		}
	}
}
