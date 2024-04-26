using General;
using Scenes.GamePlay.UI.Samurai;
using TMPro;
using UnityEngine;

public class SamuraiUI : MonoBehaviour, IInitable
{
	[SerializeField] private TextMeshProUGUI timerText;
	[SerializeField] private SamuraAnimation samuraiTextAnimation;
	[SerializeField] private SamuraAnimation samuraiImageAnimation;

	public void Init()
	{
		Hide();
	}

	public void UpdateTimer(int time)
	{
		timerText.text = time.ToString();
	}

	public void Show()
	{
		samuraiImageAnimation.Show();
		samuraiTextAnimation.Show();
	}

	public void Hide()
	{
		samuraiTextAnimation.Hide();
		samuraiImageAnimation.Hide();
	}
}
