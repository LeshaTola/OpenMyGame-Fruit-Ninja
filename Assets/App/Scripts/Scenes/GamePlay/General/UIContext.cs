using Health;
using Scenes.GamePlay.UI.Ice;
using Score;
using UnityEngine;

public class UIContext : MonoBehaviour
{
	[SerializeField] private HealthBarUI healthBarUI;
	[SerializeField] private ScoreUI scoreUI;
	[SerializeField] private SamuraiUI samuraiUI;
	[SerializeField] private IceEffectUI iceEffectUI;

	public HealthBarUI HealthBarUI { get => healthBarUI; }
	public ScoreUI ScoreUI { get => scoreUI; }
	public SamuraiUI SamuraiUI { get => samuraiUI; }
	public IceEffectUI IceEffectUI { get => iceEffectUI; }
}
