using General;
using Health;
using Score;
using Slicing.Combo;
using UnityEngine;

namespace Assets.App.Scripts.General
{
	public class Context : MonoBehaviour
	{
		[SerializeField] private ObjectPoolsContainer poolsContainer;
		[SerializeField] private HealthController healthController;
		[SerializeField] private ScoreController scoreController;
		[SerializeField] private ComboController comboController;

		public ObjectPoolsContainer PoolsContainer { get => poolsContainer; }
		public HealthController HealthController { get => healthController; }
		public ScoreController ScoreController { get => scoreController; }
		public ComboController ComboController { get => comboController; }
	}
}