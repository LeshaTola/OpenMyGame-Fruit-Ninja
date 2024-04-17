using Physics;
using TMPro;
using UnityEngine;

public class SliceScoreUI : MonoBehaviour
{
	[SerializeField] private Movement movement;
	[SerializeField] private TextMeshProUGUI scoreText;

	public Movement Movement { get => movement; }

	public void SetScore(int score)
	{
		scoreText.text = score.ToString();
	}
}
