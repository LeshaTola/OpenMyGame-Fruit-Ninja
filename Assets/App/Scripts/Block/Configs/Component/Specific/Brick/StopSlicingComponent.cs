﻿using UnityEngine;

namespace Blocks.Configs.Component
{
	[CreateAssetMenu(fileName = "StopSlicingComponent", menuName = "Configs/Blocks/Components/Specific/Brick/StopSlicingComponent")]
	public class StopSlicingComponent : BasicComponent
	{
		public override void Execute(Block block)
		{
			Context.Slicer.StopSlicing();
		}
	}
}