using Assets.App.Scripts.General;
using UnityEngine;

namespace Blocks.Configs.Component
{
	public abstract class BasicComponent : ScriptableObject, IComponent
	{
		protected Context Context;

		public void Init(Context context)
		{
			Context = context;
		}

		public abstract void Execute(Block block);

	}
}
