using UnityEngine;

namespace General.TimeProvider
{
	public class GameTimeProvider : ITimeProvider
	{
		private float timeMultiplier = 1f;

		public float TimeMultiplier
		{
			get => timeMultiplier; private set
			{
				if (value < 0f)
				{
					return;
				}
				timeMultiplier = value;
			}
		}

		public float GetTime()
		{
			return Time.deltaTime * timeMultiplier;
		}
	}
}
