using General;
using MainMenu.StateMachine;
using SaveLoad;
using StateMachine.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.UI
{
	public class MainMenuUI : MonoBehaviour, IInitable
	{
		[SerializeField] private MenuStateMachine stateMachine;
		[SerializeField] private Button playButton;
		[SerializeField] private Button exitButton;

		[SerializeField] private TextMeshProUGUI bestScoreText;

		public void Init()
		{
			Activate();

			playButton.onClick.AddListener(() =>
			{
				Deactivate();
				stateMachine.Core.SetState<LoadSceneState>();
			});
			exitButton.onClick.AddListener(() =>
			{
				Deactivate();
				Application.Quit();
			});

			UpdateBestScore(SaveLoadSystem.Load().BestScore);
		}

		private void UpdateBestScore(float score)
		{
			bestScoreText.text = score.ToString();
		}

		private void Activate()
		{
			playButton.enabled = true;
			exitButton.enabled = true;
		}

		private void Deactivate()
		{
			playButton.enabled = false;
			exitButton.enabled = false;
		}

	}
}
