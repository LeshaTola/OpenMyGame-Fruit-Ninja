namespace Blocks.Configs.Component.Specific
{
	public interface IBonusComponent
	{
		public bool IsValid { get; }
		public void StartBonus();
		public void UpdateBonus();
		public void StopBonus();
	}
}
