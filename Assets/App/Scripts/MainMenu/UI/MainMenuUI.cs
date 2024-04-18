using General;
using SaveLoad;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility.SceneLoader;

namespace MainMenu.UI
{
	public class MainMenuUI : MonoBehaviour, IInitable
	{
		[SerializeField] private Button playButton;
		[SerializeField] private Button exitButton;

		[SerializeField] private TextMeshProUGUI bestScoreText;

		public void Init()
		{
			playButton.onClick.AddListener(() => SceneLoader.LoadScene(SceneEnum.Gameplay));
			exitButton.onClick.AddListener(() => Application.Quit());

			UpdateBestScore(SaveLoadSystem.Load().BestScore);
		}

		private void UpdateBestScore(float score)
		{
			bestScoreText.text = score.ToString();
		}

	}
}
