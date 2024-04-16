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
		[SerializeField] private Knife knife;
		[SerializeField] private Spawner spawner;
		[SerializeField] private HealthController healthController;
		[SerializeField] private HealthUI healthUI;

		private void Awake()
		{
			IPlayerInput playerInput = new MousePlayerInput(mainCamera);

			knife.Init(playerInput);
			spawner.Init(new SimpleProgressor());

			healthUI.Init();
			healthController.Init();
		}
	}
}