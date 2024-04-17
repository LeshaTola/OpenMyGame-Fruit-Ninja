using Blocks;
using Blocks.Factory;
using Health;
using Input;
using Score;
using Slicing;
using Spawn;
using Spawn.Progressor;
using System.Collections.Generic;
using UnityEngine;

namespace General
{
	public class Bootstrap : MonoBehaviour
	{
		[SerializeField] private Camera mainCamera;
		[SerializeField] private List<Config> blockConfigs;

		[SerializeField] private ObjectPoolsContainer poolsContainer;

		[SerializeField] private Slicer slicer;
		[SerializeField] private Spawner spawner;

		[SerializeField] private HealthController healthController;
		[SerializeField] private HealthBarUI healthUI;
		[SerializeField] private LooseUI looseUI;

		[SerializeField] private ScoreController scoreController;
		[SerializeField] private ScoreUI scoreUI;

		private void Awake()
		{
			IPlayerInput playerInput = new MousePlayerInput(mainCamera);
			poolsContainer.Init();

			slicer.Init(playerInput);
			spawner.Init(new SimpleProgressor(), new BaseBlockFactory(poolsContainer, scoreController, healthController, blockConfigs));

			scoreUI.Init();
			healthUI.Init();
			looseUI.Init();
			healthController.Init();
		}
	}
}