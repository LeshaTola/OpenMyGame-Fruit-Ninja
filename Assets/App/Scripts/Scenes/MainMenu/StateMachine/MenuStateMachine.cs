using General;
using MainMenu.StateMachine.States;
using StateMachine.States;
using TNRD;
using UI.SceneTransitions;
using UnityEngine;
using Utility.SceneLoader;

namespace MainMenu.StateMachine

{
	public class MenuStateMachine : MonoBehaviour, IInitable
	{
		[SerializeField] private SerializableInterface<ISceneTransition> sceneTransition;

		private global::StateMachine.StateMachine core;

		public global::StateMachine.StateMachine Core { get => core; }

		public void Init()
		{
			core = new();

			core.AddState(new InitState(core, sceneTransition.Value));
			core.AddState(new MainState(core));
			core.AddState(new LoadSceneState(core, sceneTransition.Value, SceneEnum.Gameplay));

			core.SetState<InitState>();
		}
	}
}
