using UnityEngine;

namespace General
{
	public class FrameRateController : MonoBehaviour
	{
		[SerializeField, Min(0),] private int targetFrameRate = 60;

		private void Awake()
		{
			Application.targetFrameRate = targetFrameRate;
		}
	}
}
