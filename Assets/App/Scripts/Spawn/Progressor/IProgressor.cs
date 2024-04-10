namespace Spawn.Progressor
{
	public interface IProgressor
	{
		public int FruitCount { get; }
		public float FruitCooldown { get; }
		public float PackCooldown { get; }

		public void Init(SpawnConfig config, Spawner spawner);
	}
}
