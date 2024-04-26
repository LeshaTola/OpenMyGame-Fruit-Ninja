using General;
using Scenes.GamePlay.UI.Samurai;
using TMPro;
using UnityEngine;

public class SamuraiUI : MonoBehaviour, IInitable
{
	[SerializeField] private TextMeshProUGUI timerText;
	[SerializeField] private SamuraiAnimation samuraiTextAnimation;
	[SerializeField] private SamuraiAnimation samuraiImageAnimation;

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
		gameObject.SetActive(true);
		samuraiImageAnimation.Show();
		samuraiTextAnimation.Show();
	}

	public void Hide()
	{
		gameObject.SetActive(false);
		samuraiTextAnimation.Hide();
		samuraiImageAnimation.Hide();
	}
}