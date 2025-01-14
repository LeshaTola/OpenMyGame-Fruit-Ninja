﻿using System.Collections.Generic;
using UnityEngine;

namespace Blocks.Configs.Component
{
	public class MagnetComponent : BasicComponent
	{
		[Header("Prefab")]
		[SerializeField] private MagnetArea area;

		[Header("Settings")]
		[SerializeField] private float strength;
		[SerializeField] private float radius;
		[SerializeField] private float lifeTime;
		[SerializeField] private List<Config> whiteList;

		public override void Execute(Block block)
		{
			MagnetArea newMagnetArea = GameObject.Instantiate(area, block.transform.position, Quaternion.identity);
			newMagnetArea.Init(strength, radius, lifeTime, Context, whiteList);

			Context.BonusController.AddBonus(newMagnetArea);
		}
	}
}
