﻿using UnityEngine;

namespace Blocks.Configs.Component
{
	public class EffectComponent : BasicComponent
	{
		[SerializeField] private Sprite effectSprite;

		public override void Execute(Block block)
		{
			var effect = Context.PoolsContainer.Effects.Get();
			effect.transform.position = block.transform.position;
			effect.transform.rotation = Quaternion.identity;

			effect.Init(effectSprite, Context.PoolsContainer.Effects);
			effect.PlayAnimation();
		}
	}
}
