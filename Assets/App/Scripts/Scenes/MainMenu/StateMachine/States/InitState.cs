using StateMachine.States;
using UI.SceneTransitions;

namespace MainMenu.StateMachine.States
{

	public class InitState : State
	{
		ISceneTransition sceneTransition;

		public InitState(global::StateMachine.StateMachine stateMachine, ISceneTransition sceneTransition) : base(stateMachine)
		{
			this.sceneTransition = sceneTransition;
		}

		public override void Enter()
		{
			base.Enter();
			sceneTransition.PlayOff(() => stateMachine.SetState<MainState>());
		}

	}

}