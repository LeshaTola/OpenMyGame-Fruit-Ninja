using Blocks;
using Blocks.Factory;
using Health;
using Input;
using Score;
using Slicing;
using Slicing.Combo;
using Spawn;
using Spawn.Progressor;
using StateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace General
{
	public class Bootstrap : MonoBehaviour
	{
		[Header("Other")]
		[SerializeField] private List<Config> blockConfigs;

		[Header("Scene")]
		[SerializeField] private Camera mainCamera;
		[SerializeField] private ObjectPoolsContainer poolsContainer;
		[SerializeField] private ComboController comboController;
		[SerializeField] private MonoBehStateMachine stateMachine;
		[SerializeField] private Slicer slicer;
		[SerializeField] private Spawner spawner;

		[Header("Health")]
		[SerializeField] private HealthController healthController;
		[SerializeField] private HealthBarUI healthUI;
		[SerializeField] private LooseUI looseUI;

		[Header("Score")]
		[SerializeField] private ScoreController scoreController;
		[SerializeField] private ScoreUI scoreUI;

		private void Awake()
		{
			IPlayerInput playerInput = new MousePlayerInput(mainCamera);

			poolsContainer.Init();
			slicer.Init(playerInput);
			spawner.Init(new SimpleProgressor(), new BaseBlockFactory(poolsContainer, scoreController, healthController, comboController, blockConfigs));

			scoreUI.Init();
			healthUI.Init();

			looseUI.Init();

			healthController.Init();
			scoreController.Init();

			stateMachine.Init();
		}
	}
}