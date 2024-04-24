using Assets.App.Scripts.General;
using Blocks.Factory;
using Health;
using Input;
using Scenes.GamePlay.StateMachine;
using Score;
using Slicing;
using Spawn;
using Spawn.Progressor;
using UI;
using UnityEngine;

namespace General
{
	public class Bootstrap : MonoBehaviour
	{
		[Header("Context")]
		[SerializeField] private Context context;

		[Header("Scene")]
		[SerializeField] private Camera mainCamera;
		[SerializeField] private GamePlayStateMachine stateMachine;
		[SerializeField] private Slicer slicer;
		[SerializeField] private Spawner spawner;

		[Header("Health")]
		[SerializeField] private HealthBarUI healthUI;

		[Header("Score")]
		[SerializeField] private ScoreUI scoreUI;

		[Header("UI")]
		[SerializeField] private LooseUI looseUI;
		[SerializeField] private PauseUI pauseUI;

		private void Awake()
		{
			context.PoolsContainer.Init();

			IPlayerInput playerInput = new MousePlayerInput(mainCamera);
			IBlockFactory blockFactory = new BaseBlockFactory(context);

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