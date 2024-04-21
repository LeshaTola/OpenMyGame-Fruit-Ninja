using Blocks.Factory;
using Health;
using Input;
using Scenes.GamePlay.StateMachine;
using Score;
using Slicing;
using Slicing.Combo;
using Spawn;
using Spawn.Progressor;
using UI;
using UnityEngine;

namespace General
{
	public class Bootstrap : MonoBehaviour
	{
		[Header("Scene")]
		[SerializeField] private Camera mainCamera;
		[SerializeField] private ObjectPoolsContainer poolsContainer;
		[SerializeField] private ComboController comboController;
		[SerializeField] private GamePlayStateMachine stateMachine;
		[SerializeField] private Slicer slicer;
		[SerializeField] private Spawner spawner;

		[Header("Health")]
		[SerializeField] private HealthController healthController;
		[SerializeField] private HealthBarUI healthUI;

		[Header("Score")]
		[SerializeField] private ScoreController scoreController;
		[SerializeField] private ScoreUI scoreUI;

		[Header("UI")]
		[SerializeField] private LooseUI looseUI;
		[SerializeField] private PauseUI pauseUI;

		private void Awake()
		{
			poolsContainer.Init();

			IPlayerInput playerInput = new MousePlayerInput(mainCamera);
			IBlockFactory blockFactory = new BaseBlockFactory(
				poolsContainer,
				scoreController,
				healthController,
				comboController);

			slicer.Init(playerInput);
			spawner.Init(new SimpleProgressor(), blockFactory);

			scoreUI.Init();
			healthUI.Init();

			looseUI.Init();
			pauseUI.Init();

			stateMachine.Init();
		}
	}
}