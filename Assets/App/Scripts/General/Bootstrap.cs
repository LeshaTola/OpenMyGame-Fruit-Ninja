using Health;
using Input;
using Slicing;
using Spawn;
using Spawn.Progressor;
using UnityEngine;

namespace General
{
	public class Bootstrap : MonoBehaviour
	{
		[SerializeField] private Camera mainCamera;

		[SerializeField] private ObjectPoolsContainer poolsContainer;

		[SerializeField] private Slicer knife;
		[SerializeField] private Spawner spawner;

		[SerializeField] private HealthController healthController;
		[SerializeField] private HealthBarUI healthUI;
		[SerializeField] private LooseUI looseUI;

		private void Awake()
		{
			IPlayerInput playerInput = new MousePlayerInput(mainCamera);
			poolsContainer.Init();

			knife.Init(playerInput);
			spawner.Init(new SimpleProgressor());

			healthUI.Init();
			looseUI.Init();
			healthController.Init();
		}
	}
}