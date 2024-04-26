using Assets.App.Scripts.General;
using Blocks.Factory;
using Input;
using Scenes.GamePlay.StateMachine;
using Slicing;
using Spawn;
using Spawn.Progressor;
using System.Collections.Generic;
using TNRD;
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

		[SerializeField] private List<SerializableInterface<IInitable>> initables;


		private void Awake()
		{

			IPlayerInput playerInput = new MousePlayerInput(mainCamera);
			IBlockFactory blockFactory = new BaseBlockFactory(context);

			slicer.Init(playerInput);
			spawner.Init(new SimpleProgressor(), blockFactory);

			foreach (var initable in initables)
			{
				initable.Value.Init();
			}
		}
	}
}