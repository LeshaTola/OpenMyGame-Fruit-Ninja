using General;

namespace Spawn.Progressor
{
	public interface IProgressor : IResettable
	{
		public int FruitCount { get; }
		public float FruitCooldown { get; }
		public float PackCooldown { get; }
		public SpawnConfig Config { get; }

		public void Init(SpawnConfig config, Spawner spawner);
		public void StopProgression();
		public void ContinueProgression();

	}
}
