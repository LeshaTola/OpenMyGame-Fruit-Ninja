using General;
using General.TimeProvider;
using Health;
using Scenes.GamePlay.General;
using Score;
using Slicing;
using Slicing.Combo;
using Spawn;
using UnityEngine;

namespace Assets.App.Scripts.General
{
	public class Context : MonoBehaviour
	{
		[Header("Controllers")]
		[SerializeField] private ObjectPoolsContainer poolsContainer;
		[SerializeField] private HealthController healthController;
		[SerializeField] private ScoreController scoreController;
		[SerializeField] private ComboController comboController;
		[SerializeField] private BonusController bonusController;

		[Header("Other")]
		[SerializeField] private Camera mainCamera;
		[SerializeField] private Spawner spawner;
		[SerializeField] private Slicer slicer;
		[SerializeField] private UIContext uiContext;

		public ITimeProvider TimeProvider { get; private set; } = new GameTimeProvider();


		public Camera MainCamera { get => mainCamera; }
		public ObjectPoolsContainer PoolsContainer { get => poolsContainer; }
		public HealthController HealthController { get => healthController; }
		public ScoreController ScoreController { get => scoreController; }
		public ComboController ComboController { get => comboController; }
		public Spawner Spawner { get => spawner; }
		public Slicer Slicer { get => slicer; }
		public UIContext UiContext { get => uiContext; }
		public BonusController BonusController { get => bonusController; }
	}
}