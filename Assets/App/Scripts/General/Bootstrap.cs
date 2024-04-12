using Input;
using Spawn;
using Spawn.Progressor;
using UnityEngine;

namespace General
{
	public class Bootstrap : MonoBehaviour
	{
		[SerializeField] private Knife.Knife knife;
		[SerializeField] private Spawner spawner;

		private void Awake()
		{
			IPlayerInput playerInput = new MousePlayerInput();

			knife.Init(playerInput);
			spawner.Init(new SimpleProgressor());
		}
	}
}