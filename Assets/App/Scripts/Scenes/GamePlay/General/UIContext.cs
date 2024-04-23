using Health;
using Score;
using UnityEngine;

public class UIContext : MonoBehaviour
{
	[SerializeField] private HealthBarUI healthBarUI;
	[SerializeField] private ScoreUI scoreUI;

	public HealthBarUI HealthBarUI { get => healthBarUI; }
	public ScoreUI ScoreUI { get => scoreUI; }
}
