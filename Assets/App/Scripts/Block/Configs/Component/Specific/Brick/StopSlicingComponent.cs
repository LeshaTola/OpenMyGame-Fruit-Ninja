namespace Blocks.Configs.Component
{
	public class StopSlicingComponent : BasicComponent
	{
		public override void Execute(Block block)
		{
			Context.Slicer.StopSlicing();
		}
	}
}
