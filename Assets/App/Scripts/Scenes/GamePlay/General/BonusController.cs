using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.GamePlay.General
{
	public class BonusController : MonoBehaviour
	{
		public List<Action> Actions { get; private set; } = new();

		private void Update()
		{

		}

		public void CleanUp()
		{
			foreach (var action in Actions)
			{
				action();
			}
		}
	}
}
