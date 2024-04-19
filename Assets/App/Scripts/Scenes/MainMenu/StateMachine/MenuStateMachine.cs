using General;
using StateMachine.States;
using TNRD;
using UI.SceneTransitions;
using UnityEngine;
using Utility.SceneLoader;

namespace MainMenu

{
	public class MenuStateMachine : MonoBehaviour, IInitable
	{
		[SerializeField] private SerializableInterface<ISceneTransition> sceneTransition;

		private StateMachine.StateMachine core;

		public StateMachine.StateMachine Core { get => core; }

		public void Init()
		{
			core = new();

			core.AddState(new InitState(core));
			core.AddState(new LoadSceneState(core, sceneTransition.Value, SceneEnum.Gameplay));

			core.SetState<InitState>();
		}
	}
}
